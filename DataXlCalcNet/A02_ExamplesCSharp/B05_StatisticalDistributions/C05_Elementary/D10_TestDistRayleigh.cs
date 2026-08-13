
/* If defined includes code requiring ArbPrecNet. Is set automatically */
#define HasArbPrecNet

#region Usings
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
    ArbPrec.SetDps(76);
#endif
    DemoDistRayleighPdf();
    DemoDistRayleighCdf();
    DemoDistRayleighSurvivalFunction();
    DemoDistRayleighHazardFunction();
    DemoDistRayleighCumulativeHazardFunction();
    DemoDistRayleighQuantileFunction();
    DemoDistRayleighInverseSurvivalFunction();
    DemoDistRayleighMode();
    DemoDistRayleighMedian();
    DemoDistRayleighMean();
    DemoDistRayleighVariance();
    DemoDistRayleighStDev();
    DemoDistRayleighSkewness();
    DemoDistRayleighKurtosis();
    DemoDistRayleighKurtosisExcess();
    DemoDistRayleighSupportLowerEndpoint();
    DemoDistRayleighSupportUpperEndpoint();
    DemoDistRayleighRangeLowerEndpoint();
    DemoDistRayleighRangeUpperEndpoint();
}


#region Demo DistRayleigh


#region Pdf
public static void DemoDistRayleighPdf()
{
    Console.WriteLine("Demo Rayleigh Distribution: Pdf");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_rayleigh(b).pdf(x); " 
        + "b={0}, x={1}" + "\"" + ">", b, x);

    Double Res00 = math53.rayleigh_pdf(b, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_rayleigh(b).pdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).pdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).pdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).pdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).pdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).pdf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
    }
}
#endregion

#region Cdf
public static void DemoDistRayleighCdf()
{
    Console.WriteLine("Demo Rayleigh Distribution: Cdf");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_rayleigh(b).cdf(x); " 
        + "b={0}, x={1}" + "\"" + ">", b, x);

    Double Res00 = math53.rayleigh_cdf(b, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_rayleigh(b).cdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).cdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).cdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).cdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).cdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).cdf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // b
}
#endregion

#region Survival Function
public static void DemoDistRayleighSurvivalFunction()
{
    Console.WriteLine("Demo Rayleigh Distribution: Survival Function");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_rayleigh(b).sf(x); " 
        + "b={0}, x={1}" + "\"" + ">", b, x);

    Single Res01 = sreal.dist_rayleigh(b).sf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).sf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).sf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).sf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).sf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).sf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // b
}
#endregion

#region Hazard Function

public static void DemoDistRayleighHazardFunction()
{
    Console.WriteLine("Demo Rayleigh Distribution: Hazard Function");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_rayleigh(b).hf(x); " 
        + "b={0}, x={1}" + "\"" + ">", b, x);

    Single Res01 = sreal.dist_rayleigh(b).hf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).hf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).hf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).hf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).hf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).hf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // b
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistRayleighCumulativeHazardFunction()
{
    Console.WriteLine("Demo Rayleigh Distribution: Cumulative Hazard Function");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_rayleigh(b).chf(x); " 
        + "b={0}, x={1}" + "\"" + ">", b, x);

    Single Res01 = sreal.dist_rayleigh(b).chf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).chf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).chf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).chf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).chf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).chf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // b
}
#endregion

#region Quantile Function
public static void DemoDistRayleighQuantileFunction()
{
    Console.WriteLine("Demo Rayleigh Distribution: Quantile Function");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_rayleigh(b).qtf(x); " 
        + "b={0}, q={1}" + "\"" + ">", b, q);

    Double Res00 = math53.rayleigh_qtf(b, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_rayleigh(b).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // b
}
#endregion

#region Inverse Survival Function
public static void DemoDistRayleighInverseSurvivalFunction()
{
    Console.WriteLine("Demo Rayleigh Distribution: Inverse Quantile Function");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_rayleigh(b).isf(x); " 
        + "b={0}, q={1}" + "\"" + ">", b, q);

    Single Res01 = sreal.dist_rayleigh(b).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).isf(q);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // b
}
#endregion

#region Mode
public static void DemoDistRayleighMode()
{
    Console.WriteLine("Demo Rayleigh Distribution: Mode");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    Single Res01 = sreal.dist_rayleigh(b).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).mode();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } // b
}
#endregion

#region Median
public static void DemoDistRayleighMedian()
{
    Console.WriteLine("Demo Rayleigh Distribution: Median");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    Single Res01 = sreal.dist_rayleigh(b).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).median();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Mean
public static void DemoDistRayleighMean()
{
    Console.WriteLine("Demo Rayleigh Distribution: Mean");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    Single Res01 = sreal.dist_rayleigh(b).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).mean();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Variance
public static void DemoDistRayleighVariance()
{
    Console.WriteLine("Demo Rayleigh Distribution: Variance");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    Single Res01 = sreal.dist_rayleigh(b).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).variance();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region StDev
public static void DemoDistRayleighStDev()
{
    Console.WriteLine("Demo Rayleigh Distribution: Standard Deviation");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    Single Res01 = sreal.dist_rayleigh(b).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).stdev();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Skewness
public static void DemoDistRayleighSkewness()
{
    Console.WriteLine("Demo Rayleigh Distribution: Skewness");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);

    Single Res01 = sreal.dist_rayleigh(b).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).skewness();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Kurtosis
public static void DemoDistRayleighKurtosis()
{
    Console.WriteLine("Demo Rayleigh Distribution: Kurtosis");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);
    Single Res01 = sreal.dist_rayleigh(b).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).kurtosis();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region KurtosisExcess
public static void DemoDistRayleighKurtosisExcess()
{
    Console.WriteLine("Demo Rayleigh Distribution: Kurtosis Excess");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b); b={0}" 
        + "\"" + ">", b);
    Single Res01 = sreal.dist_rayleigh(b).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_rayleigh(b).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_rayleigh(b).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_rayleigh(b).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_rayleigh(b).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_rayleigh(b).kurtosis_excess();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistRayleighSupportLowerEndpoint()
{
    Console.WriteLine("Demo Rayleigh Distribution: Support");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b).support_lower_endpoint(); b={0}" 
        + "\"" + ">", b);
    Single Res01L = sreal.dist_rayleigh(b).support_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_rayleigh(b).support_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_rayleigh(b).support_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_rayleigh(b).support_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_rayleigh(b).support_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_rayleigh(b).support_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region SupportUpperEndpoint
public static void DemoDistRayleighSupportUpperEndpoint()
{
    Console.WriteLine("Demo Rayleigh Distribution: Support Lower Endpoint");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b).support_upper_endpoint(); b={0}" 
        + "\"" + ">", b);
    Single Res01R = sreal.dist_rayleigh(b).support_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_rayleigh(b).support_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_rayleigh(b).support_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_rayleigh(b).support_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_rayleigh(b).support_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_rayleigh(b).support_upper_endpoint();
    Console.WriteLine("mreal: {0}", Res06R);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistRayleighRangeLowerEndpoint()
{   Console.WriteLine("Demo Rayleigh Distribution: Range UpperEndpoint");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b).range_lower_endpoint(); b={0}" 
        + "\"" + ">", b);
    Single Res01L = sreal.dist_rayleigh(b).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_rayleigh(b).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_rayleigh(b).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_rayleigh(b).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_rayleigh(b).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_rayleigh(b).range_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region RangeUpperEndpoint
public static void DemoDistRayleighRangeUpperEndpoint()
{
    Console.WriteLine("Demo Rayleigh Distribution: Range UpperEndpoint");
    foreach (var b in new[] { 1.5d, 2.5d, 3.5d }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_rayleigh(b).range_upper_endpoint(); b={0}" 
        + "\"" + ">", b);
    Single Res01R = sreal.dist_rayleigh(b).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_rayleigh(b).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_rayleigh(b).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_rayleigh(b).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_rayleigh(b).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_rayleigh(b).range_upper_endpoint();
    Console.WriteLine("mreal: {0}", Res06R);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
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

