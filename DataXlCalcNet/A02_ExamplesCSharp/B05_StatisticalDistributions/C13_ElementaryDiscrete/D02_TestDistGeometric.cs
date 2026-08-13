
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
    DemoDistGeometricPmf();
    DemoDistGeometricCdf();
    DemoDistGeometricSurvivalFunction();
    DemoDistGeometricHazardFunction();
    DemoDistGeometricCumulativeHazardFunction();
    DemoDistGeometricQuantileFunction();
    DemoDistGeometricInverseSurvivalFunction();
    DemoDistGeometricMode();
    DemoDistGeometricMedian();
    DemoDistGeometricMean();
    DemoDistGeometricVariance();
    DemoDistGeometricStDev();
    DemoDistGeometricSkewness();
    DemoDistGeometricKurtosis();
    DemoDistGeometricKurtosisExcess();
    DemoDistGeometricSupportLowerEndpoint();
    DemoDistGeometricSupportUpperEndpoint();
    DemoDistGeometricRangeLowerEndpoint();
    DemoDistGeometricRangeUpperEndpoint();
}


#region Demo DistGeometric


#region Pmf
public static void DemoDistGeometricPmf()
{
    Console.WriteLine("Demo Geometric Distribution: Pmf");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    foreach (var k in new[] { 0, 33, 75, 100 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_geometric(p).pmf(k); " 
        + "p={0}, k={1}" + "\"" + ">", p, k);

    Double Res00 = math53.geometric_pmf(p, (int)k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_geometric(p).pmf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).pmf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).pmf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).pmf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).pmf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).pmf(k);
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
public static void DemoDistGeometricCdf()
{
    Console.WriteLine("Demo Geometric Distribution: Cdf");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    foreach (var k in new[] { 0, 33, 75, 100 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_geometric(p).cdf(k); " 
        + "p={0}, k={1}" + "\"" + ">", p, k);

    Double Res00 = math53.geometric_cdf(p, (int)k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_geometric(p).cdf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).cdf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).cdf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).cdf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).cdf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).cdf(k);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Survival Function
public static void DemoDistGeometricSurvivalFunction()
{
    Console.WriteLine("Demo Geometric Distribution: Survival Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    foreach (var k in new[] { 0, 33, 75, 100 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_geometric(p).sf(k); " 
        + "p={0}, k={1}" + "\"" + ">", p, k);

    Single Res01 = sreal.dist_geometric(p).sf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).sf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).sf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).sf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).sf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).sf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Hazard Function

public static void DemoDistGeometricHazardFunction()
{
    Console.WriteLine("Demo Geometric Distribution: Hazard Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    foreach (var k in new[] { 0, 33, 75, 100 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_geometric(p).hf(k); " 
        + "p={0}, k={1}" + "\"" + ">", p, k);

    Single Res01 = sreal.dist_geometric(p).hf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).hf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).hf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).hf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).hf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).hf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistGeometricCumulativeHazardFunction()
{
    Console.WriteLine("Demo Geometric Distribution: Cumulative Hazard Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    foreach (var k in new[] { 0, 33, 75, 100 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_geometric(p).chf(k); " 
        + "p={0}, k={1}" + "\"" + ">", p, k);

    Single Res01 = sreal.dist_geometric(p).chf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).chf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).chf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).chf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).chf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).chf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Quantile Function
public static void DemoDistGeometricQuantileFunction()
{
    Console.WriteLine("Demo Geometric Distribution: Quantile Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_geometric(p).qtf(k); " 
        + "p={0}, q={1}" + "\"" + ">", p, q);

    Double Res00 = math53.geometric_qtf(p, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_geometric(p).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Inverse Survival Function
public static void DemoDistGeometricInverseSurvivalFunction()
{
    Console.WriteLine("Demo Geometric Distribution: Inverse Quantile Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_geometric(p).isf(k); " 
        + "p={0}, q={1}" + "\"" + ">", p, q);

    Single Res01 = sreal.dist_geometric(p).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).isf(q);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Mode
public static void DemoDistGeometricMode()
{
    Console.WriteLine("Demo Geometric Distribution: Mode");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_geometric(p).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).mode();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Median
public static void DemoDistGeometricMedian()
{
    Console.WriteLine("Demo Geometric Distribution: Median");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_geometric(p).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).median();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Mean
public static void DemoDistGeometricMean()
{
    Console.WriteLine("Demo Geometric Distribution: Mean");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_geometric(p).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).mean();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Variance
public static void DemoDistGeometricVariance()
{
    Console.WriteLine("Demo Geometric Distribution: Variance");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_geometric(p).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).variance();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region StDev
public static void DemoDistGeometricStDev()
{
    Console.WriteLine("Demo Geometric Distribution: Standard Deviation");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_geometric(p).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).stdev();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Skewness
public static void DemoDistGeometricSkewness()
{
    Console.WriteLine("Demo Geometric Distribution: Skewness");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_geometric(p).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).skewness();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Kurtosis
public static void DemoDistGeometricKurtosis()
{
    Console.WriteLine("Demo Geometric Distribution: Kurtosis");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);
    Single Res01 = sreal.dist_geometric(p).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).kurtosis();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region KurtosisExcess
public static void DemoDistGeometricKurtosisExcess()
{
    Console.WriteLine("Demo Geometric Distribution: Kurtosis Excess");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p); p={0}" 
        + "\"" + ">", p);
    Single Res01 = sreal.dist_geometric(p).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_geometric(p).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_geometric(p).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_geometric(p).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_geometric(p).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_geometric(p).kurtosis_excess();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistGeometricSupportLowerEndpoint()
{
    Console.WriteLine("Demo Geometric Distribution: Support");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p).support_lower_endpoint(); p={0}" 
        + "\"" + ">", p);
    Single Res01L = sreal.dist_geometric(p).support_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_geometric(p).support_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_geometric(p).support_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_geometric(p).support_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_geometric(p).support_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_geometric(p).support_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region SupportUpperEndpoint
public static void DemoDistGeometricSupportUpperEndpoint()
{
    Console.WriteLine("Demo Geometric Distribution: Support Lower Endpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p).support_upper_endpoint(); p={0}" 
        + "\"" + ">", p);
    Single Res01R = sreal.dist_geometric(p).support_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_geometric(p).support_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_geometric(p).support_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_geometric(p).support_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_geometric(p).support_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_geometric(p).support_upper_endpoint();
    Console.WriteLine("mreal: {0}", Res06R);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistGeometricRangeLowerEndpoint()
{   Console.WriteLine("Demo Geometric Distribution: Range UpperEndpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p).range_lower_endpoint(); p={0}" 
        + "\"" + ">", p);
    Single Res01L = sreal.dist_geometric(p).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_geometric(p).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_geometric(p).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_geometric(p).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_geometric(p).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_geometric(p).range_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region RangeUpperEndpoint
public static void DemoDistGeometricRangeUpperEndpoint()
{
    Console.WriteLine("Demo Geometric Distribution: Range UpperEndpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_geometric(p).range_upper_endpoint(); p={0}" 
        + "\"" + ">", p);
    Single Res01R = sreal.dist_geometric(p).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_geometric(p).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_geometric(p).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_geometric(p).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_geometric(p).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_geometric(p).range_upper_endpoint();
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

