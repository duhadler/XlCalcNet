
#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
#endregion


static class Program
{

public static void MainTests()
{
    DemoDistHoltsmarkPdf();
    DemoDistHoltsmarkCdf();
    DemoDistHoltsmarkSurvivalFunction();
    DemoDistHoltsmarkHazardFunction();
    DemoDistHoltsmarkCumulativeHazardFunction();
    DemoDistHoltsmarkQuantileFunction();
    DemoDistHoltsmarkInverseSurvivalFunction();
    DemoDistHoltsmarkMode();
    DemoDistHoltsmarkMedian();
    DemoDistHoltsmarkMean();
    DemoDistHoltsmarkVariance();
    DemoDistHoltsmarkStDev();
    DemoDistHoltsmarkSkewness();
    DemoDistHoltsmarkKurtosis();
    DemoDistHoltsmarkKurtosisExcess();
    DemoDistHoltsmarkSupportLowerEndpoint();
    DemoDistHoltsmarkSupportUpperEndpoint();
    DemoDistHoltsmarkRangeLowerEndpoint();
    DemoDistHoltsmarkRangeUpperEndpoint();
}


#region Demo DistHoltsmark


#region Pdf
public static void DemoDistHoltsmarkPdf()
{
    Console.WriteLine("Demo Holtsmark Distribution: Pdf");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_holtsmark(mu, c).pdf(x); " 
        + "mu={0}, c={1}, x={2}" + "\"" + ">", mu, c, x);

    Double Res00 = math53.holtsmark_pdf(mu, c, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_holtsmark(mu, c).pdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).pdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).pdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).pdf(x);
    Console.WriteLine(" qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Cdf
public static void DemoDistHoltsmarkCdf()
{
    Console.WriteLine("Demo Holtsmark Distribution: Cdf");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_holtsmark(mu, c).cdf(x); " 
        + "mu={0}, c={1}, x={2}" + "\"" + ">", mu, c, x);

    Double Res00 = math53.holtsmark_cdf(mu, c, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_holtsmark(mu, c).cdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).cdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).cdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).cdf(x);
    Console.WriteLine(" qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}
#endregion

#region Survival Function
public static void DemoDistHoltsmarkSurvivalFunction()
{
    Console.WriteLine("Demo Holtsmark Distribution: Survival Function");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_holtsmark(mu, c).sf(x); " 
        + "mu={0}, c={1}, x={2}" + "\"" + ">", mu, c, x);

    Single Res01 = sreal.dist_holtsmark(mu, c).sf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).sf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).sf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).sf(x);
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}
#endregion

#region Hazard Function

public static void DemoDistHoltsmarkHazardFunction()
{
    Console.WriteLine("Demo Holtsmark Distribution: Hazard Function");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_holtsmark(mu, c).hf(x); " 
        + "mu={0}, c={1}, x={2}" + "\"" + ">", mu, c, x);

    Single Res01 = sreal.dist_holtsmark(mu, c).hf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).hf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).hf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).hf(x);
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistHoltsmarkCumulativeHazardFunction()
{
    Console.WriteLine("Demo Holtsmark Distribution: Cumulative Hazard Function");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_holtsmark(mu, c).chf(x); " 
        + "mu={0}, c={1}, x={2}" + "\"" + ">", mu, c, x);

    Single Res01 = sreal.dist_holtsmark(mu, c).chf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).chf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).chf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).chf(x);
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}
#endregion

#region Quantile Function
public static void DemoDistHoltsmarkQuantileFunction()
{
    Console.WriteLine("Demo Holtsmark Distribution: Quantile Function");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_holtsmark(mu, c).qtf(q); " + 
        "mu={0}, c={1}, q={2}" + "\"" + ">", mu, c, q);

    Double Res00 = math53.holtsmark_qtf(mu, c, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_holtsmark(mu, c).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}
#endregion

#region Inverse Survival Function
public static void DemoDistHoltsmarkInverseSurvivalFunction()
{
    Console.WriteLine("Demo Holtsmark Distribution: Inverse Quantile Function");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_holtsmark(mu, c).isf(q); " + 
        "mu={0}, c={1}, q={2}" + "\"" + ">", mu, c, q);

    Single Res01 = sreal.dist_holtsmark(mu, c).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).isf(q);
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}
#endregion

#region Mode
public static void DemoDistHoltsmarkMode()
{
    Console.WriteLine("Demo Holtsmark Distribution: Mode");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).mode(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_holtsmark(mu, c).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).mode();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Median
public static void DemoDistHoltsmarkMedian()
{
    Console.WriteLine("Demo Holtsmark Distribution: Median");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).median(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_holtsmark(mu, c).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).median();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Mean
public static void DemoDistHoltsmarkMean()
{
    Console.WriteLine("Demo Holtsmark Distribution: Mean");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).mean(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_holtsmark(mu, c).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).mean();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Variance
public static void DemoDistHoltsmarkVariance()
{
    Console.WriteLine("Demo Holtsmark Distribution: Variance");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).variance(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_holtsmark(mu, c).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).variance();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region StDev
public static void DemoDistHoltsmarkStDev()
{
    Console.WriteLine("Demo Holtsmark Distribution: Standard Deviation");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).stdev(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_holtsmark(mu, c).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).stdev();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Skewness
public static void DemoDistHoltsmarkSkewness()
{
    Console.WriteLine("Demo Holtsmark Distribution: Skewness");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).skewness(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_holtsmark(mu, c).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).skewness();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Kurtosis
public static void DemoDistHoltsmarkKurtosis()
{
    Console.WriteLine("Demo Holtsmark Distribution: Kurtosis");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).kurtosis(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01 = sreal.dist_holtsmark(mu, c).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region KurtosisExcess
public static void DemoDistHoltsmarkKurtosisExcess()
{
    Console.WriteLine("Demo Holtsmark Distribution: Kurtosis Excess");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).kurtosis_excess(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01 = sreal.dist_holtsmark(mu, c).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_holtsmark(mu, c).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_holtsmark(mu, c).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_holtsmark(mu, c).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistHoltsmarkSupportLowerEndpoint()
{
    Console.WriteLine("Demo Holtsmark Distribution: Support, Lower Endpoint");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).support_lower_endpoint();" 
        + " mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01L = sreal.dist_holtsmark(mu, c).support_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_holtsmark(mu, c).support_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_holtsmark(mu, c).support_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_holtsmark(mu, c).support_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportUpperEndpoint
public static void DemoDistHoltsmarkSupportUpperEndpoint()
{
    Console.WriteLine("Demo Holtsmark Distribution: Support, Upper Endpoint");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).support_upper_endpoint()" 
        + "; mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01R = sreal.dist_holtsmark(mu, c).support_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_holtsmark(mu, c).support_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_holtsmark(mu, c).support_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_holtsmark(mu, c).support_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistHoltsmarkRangeLowerEndpoint()
{
    Console.WriteLine("Demo Holtsmark Distribution: Range, Lower Endpoint");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).range_lower_endpoint();"
        + " mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01L = sreal.dist_holtsmark(mu, c).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_holtsmark(mu, c).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_holtsmark(mu, c).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_holtsmark(mu, c).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeUpperEndpoint
public static void DemoDistHoltsmarkRangeUpperEndpoint()
{
    Console.WriteLine("Demo Holtsmark Distribution: Range, Upper Endpoint");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_holtsmark(mu, c).range_upper_endpoint();"
        + " mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01R = sreal.dist_holtsmark(mu, c).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_holtsmark(mu, c).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_holtsmark(mu, c).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_holtsmark(mu, c).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion


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

