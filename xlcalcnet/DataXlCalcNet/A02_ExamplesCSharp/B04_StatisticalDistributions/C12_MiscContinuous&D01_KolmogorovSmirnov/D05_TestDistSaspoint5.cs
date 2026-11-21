
#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
#endregion


static class Program
{

public static void MainTests()
{
    DemoDistSaspoint5Pdf();
    DemoDistSaspoint5Cdf();
    DemoDistSaspoint5SurvivalFunction();
    DemoDistSaspoint5HazardFunction();
    DemoDistSaspoint5CumulativeHazardFunction();
    DemoDistSaspoint5QuantileFunction();
    DemoDistSaspoint5InverseSurvivalFunction();
    DemoDistSaspoint5Mode();
    DemoDistSaspoint5Median();
    DemoDistSaspoint5Mean();
    DemoDistSaspoint5Variance();
    DemoDistSaspoint5StDev();
    DemoDistSaspoint5Skewness();
    DemoDistSaspoint5Kurtosis();
    DemoDistSaspoint5KurtosisExcess();
    DemoDistSaspoint5SupportLowerEndpoint();
    DemoDistSaspoint5SupportUpperEndpoint();
    DemoDistSaspoint5RangeLowerEndpoint();
    DemoDistSaspoint5RangeUpperEndpoint();
}


#region Demo DistSaspoint5


#region Pdf
public static void DemoDistSaspoint5Pdf()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Pdf");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_saspoint5(mu, c).pdf(x); " 
        + "mu={0}, c={1}, x={2}" + "\"" + ">", mu, c, x);

    Double Res00 = math53.saspoint5_pdf(mu, c, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_saspoint5(mu, c).pdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).pdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).pdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).pdf(x);
    Console.WriteLine(" qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Cdf
public static void DemoDistSaspoint5Cdf()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Cdf");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_saspoint5(mu, c).cdf(x); " 
        + "mu={0}, c={1}, x={2}" + "\"" + ">", mu, c, x);

    Double Res00 = math53.saspoint5_cdf(mu, c, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_saspoint5(mu, c).cdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).cdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).cdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).cdf(x);
    Console.WriteLine(" qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}
#endregion

#region Survival Function
public static void DemoDistSaspoint5SurvivalFunction()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Survival Function");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_saspoint5(mu, c).sf(x); " 
        + "mu={0}, c={1}, x={2}" + "\"" + ">", mu, c, x);

    Single Res01 = sreal.dist_saspoint5(mu, c).sf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).sf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).sf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).sf(x);
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}
#endregion

#region Hazard Function

public static void DemoDistSaspoint5HazardFunction()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Hazard Function");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_saspoint5(mu, c).hf(x); " 
        + "mu={0}, c={1}, x={2}" + "\"" + ">", mu, c, x);

    Single Res01 = sreal.dist_saspoint5(mu, c).hf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).hf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).hf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).hf(x);
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistSaspoint5CumulativeHazardFunction()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Cumulative Hazard Function");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_saspoint5(mu, c).chf(x); " 
        + "mu={0}, c={1}, x={2}" + "\"" + ">", mu, c, x);

    Single Res01 = sreal.dist_saspoint5(mu, c).chf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).chf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).chf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).chf(x);
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}
#endregion

#region Quantile Function
public static void DemoDistSaspoint5QuantileFunction()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Quantile Function");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_saspoint5(mu, c).qtf(q); " + 
        "mu={0}, c={1}, q={2}" + "\"" + ">", mu, c, q);

    Double Res00 = math53.saspoint5_qtf(mu, c, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_saspoint5(mu, c).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}
#endregion

#region Inverse Survival Function
public static void DemoDistSaspoint5InverseSurvivalFunction()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Inverse Quantile Function");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c); mu={0}, c={1}" 
        + "\"" + ">", mu, c);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_saspoint5(mu, c).isf(q); " + 
        "mu={0}, c={1}, q={2}" + "\"" + ">", mu, c, q);

    Single Res01 = sreal.dist_saspoint5(mu, c).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).isf(q);
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // c, mu
}
#endregion

#region Mode
public static void DemoDistSaspoint5Mode()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Mode");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).mode(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_saspoint5(mu, c).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).mode();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Median
public static void DemoDistSaspoint5Median()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Median");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).median(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_saspoint5(mu, c).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).median();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Mean
public static void DemoDistSaspoint5Mean()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Mean");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).mean(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_saspoint5(mu, c).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).mean();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Variance
public static void DemoDistSaspoint5Variance()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Variance");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).variance(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_saspoint5(mu, c).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).variance();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region StDev
public static void DemoDistSaspoint5StDev()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Standard Deviation");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).stdev(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_saspoint5(mu, c).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).stdev();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Skewness
public static void DemoDistSaspoint5Skewness()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Skewness");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).skewness(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);

    Single Res01 = sreal.dist_saspoint5(mu, c).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).skewness();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Kurtosis
public static void DemoDistSaspoint5Kurtosis()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Kurtosis");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).kurtosis(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01 = sreal.dist_saspoint5(mu, c).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region KurtosisExcess
public static void DemoDistSaspoint5KurtosisExcess()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Kurtosis Excess");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).kurtosis_excess(); " +
        " mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01 = sreal.dist_saspoint5(mu, c).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_saspoint5(mu, c).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_saspoint5(mu, c).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_saspoint5(mu, c).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistSaspoint5SupportLowerEndpoint()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Support, Lower Endpoint");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).support_lower_endpoint();" 
        + " mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01L = sreal.dist_saspoint5(mu, c).support_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_saspoint5(mu, c).support_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_saspoint5(mu, c).support_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_saspoint5(mu, c).support_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportUpperEndpoint
public static void DemoDistSaspoint5SupportUpperEndpoint()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Support, Upper Endpoint");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).support_upper_endpoint()" 
        + "; mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01R = sreal.dist_saspoint5(mu, c).support_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_saspoint5(mu, c).support_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_saspoint5(mu, c).support_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_saspoint5(mu, c).support_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistSaspoint5RangeLowerEndpoint()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Range, Lower Endpoint");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).range_lower_endpoint();"
        + " mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01L = sreal.dist_saspoint5(mu, c).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_saspoint5(mu, c).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_saspoint5(mu, c).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_saspoint5(mu, c).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeUpperEndpoint
public static void DemoDistSaspoint5RangeUpperEndpoint()
{
    Console.WriteLine("Demo Saspoint5 Distribution: Range, Upper Endpoint");
    foreach (var mu in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var c in new[] { 5.1, 12.1, 53.5 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_saspoint5(mu, c).range_upper_endpoint();"
        + " mu={0}, c={1}" + "\"" + ">", mu, c);
    Single Res01R = sreal.dist_saspoint5(mu, c).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_saspoint5(mu, c).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_saspoint5(mu, c).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_saspoint5(mu, c).range_upper_endpoint();
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

