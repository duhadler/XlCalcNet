
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
    DemoDistBinomialPmf();
    DemoDistBinomialCdf();
    DemoDistBinomialSurvivalFunction();
    DemoDistBinomialHazardFunction();
    DemoDistBinomialCumulativeHazardFunction();
    DemoDistBinomialQuantileFunction();
    DemoDistBinomialInverseSurvivalFunction();
    DemoDistBinomialMode();
    DemoDistBinomialMedian();
    DemoDistBinomialMean();
    DemoDistBinomialVariance();
    DemoDistBinomialStDev();
    DemoDistBinomialSkewness();
    DemoDistBinomialKurtosis();
    DemoDistBinomialKurtosisExcess();
    DemoDistBinomialSupportLowerEndpoint();
    DemoDistBinomialSupportUpperEndpoint();
    DemoDistBinomialRangeLowerEndpoint();
    DemoDistBinomialRangeUpperEndpoint();
}


#region Demo DistBinomial


#region Pmf
public static void DemoDistBinomialPmf()
{
    Console.WriteLine("Demo Binomial Distribution: Pmf");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p); p={0}, n={1}" 
        + "\"" + ">", p, n);

    foreach (var k in new[] { 3, 10, 20  }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_binomial(n, p).pmf(k); " 
        + "p={0}, n={1}, k={2}" + "\"" + ">", p, n, k);

    Double Res00 = math53.binomial_pmf(n, p, k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_binomial(n, p).pmf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).pmf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).pmf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).pmf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).pmf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).pmf(k);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Cdf
public static void DemoDistBinomialCdf()
{
    Console.WriteLine("Demo Binomial Distribution: Cdf");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p); p={0}, n={1}" 
        + "\"" + ">", p, n);

    foreach (var k in new[] { 3, 10, 20  }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_binomial(n, p).cdf(k); " 
        + "p={0}, n={1}, k={2}" + "\"" + ">", p, n, k);

    Double Res00 = math53.binomial_cdf(n, p, k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_binomial(n, p).cdf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).cdf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).cdf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).cdf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).cdf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).cdf(k);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // n, p
}
#endregion

#region Survival Function
public static void DemoDistBinomialSurvivalFunction()
{
    Console.WriteLine("Demo Binomial Distribution: Survival Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p); p={0}, n={1}" 
        + "\"" + ">", p, n);

    foreach (var k in new[] { 3, 10, 20  }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_binomial(n, p).sf(k); " 
        + "p={0}, n={1}, k={2}" + "\"" + ">", p, n, k);

    Single Res01 = sreal.dist_binomial(n, p).sf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).sf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).sf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).sf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).sf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).sf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // n, p
}
#endregion

#region Hazard Function

public static void DemoDistBinomialHazardFunction()
{
    Console.WriteLine("Demo Binomial Distribution: Hazard Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p); p={0}, n={1}" 
        + "\"" + ">", p, n);

    foreach (var k in new[] { 3, 10, 20  }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_binomial(n, p).hf(k); " 
        + "p={0}, n={1}, k={2}" + "\"" + ">", p, n, k);

    Single Res01 = sreal.dist_binomial(n, p).hf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).hf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).hf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).hf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).hf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).hf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // n, p
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistBinomialCumulativeHazardFunction()
{
    Console.WriteLine("Demo Binomial Distribution: Cumulative Hazard Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p); p={0}, n={1}" 
        + "\"" + ">", p, n);

    foreach (var k in new[] { 3, 10, 20  }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_binomial(n, p).chf(k); " 
        + "p={0}, n={1}, k={2}" + "\"" + ">", p, n, k);

    Single Res01 = sreal.dist_binomial(n, p).chf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).chf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).chf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).chf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).chf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).chf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // n, p
}
#endregion

#region Quantile Function
public static void DemoDistBinomialQuantileFunction()
{
    Console.WriteLine("Demo Binomial Distribution: Quantile Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p); p={0}, n={1}" 
        + "\"" + ">", p, n);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_binomial(n, p).qtf(q); " + 
        "p={0}, n={1}, q={2}" + "\"" + ">", p, n, q);

    Double Res00 = math53.binomial_qtf(n, p, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_binomial(n, p).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // n, p
}
#endregion

#region Inverse Survival Function
public static void DemoDistBinomialInverseSurvivalFunction()
{
    Console.WriteLine("Demo Binomial Distribution: Inverse Quantile Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p); p={0}, n={1}" 
        + "\"" + ">", p, n);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_binomial(n, p).isf(q); " + 
        "p={0}, n={1}, q={2}" + "\"" + ">", p, n, q);

    Single Res01 = sreal.dist_binomial(n, p).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).isf(q);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // n, p
}
#endregion

#region Mode
public static void DemoDistBinomialMode()
{
    Console.WriteLine("Demo Binomial Distribution: Mode");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p).mode(); " +
        " p={0}, n={1}" + "\"" + ">", p, n);

    Single Res01 = sreal.dist_binomial(n, p).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).mode();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Median
public static void DemoDistBinomialMedian()
{
    Console.WriteLine("Demo Binomial Distribution: Median");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p).median(); " +
        " p={0}, n={1}" + "\"" + ">", p, n);

    Single Res01 = sreal.dist_binomial(n, p).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).median();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Mean
public static void DemoDistBinomialMean()
{
    Console.WriteLine("Demo Binomial Distribution: Mean");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p).mean(); " +
        " p={0}, n={1}" + "\"" + ">", p, n);

    Single Res01 = sreal.dist_binomial(n, p).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).mean();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Variance
public static void DemoDistBinomialVariance()
{
    Console.WriteLine("Demo Binomial Distribution: Variance");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p).variance(); " +
        " p={0}, n={1}" + "\"" + ">", p, n);

    Single Res01 = sreal.dist_binomial(n, p).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).variance();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region StDev
public static void DemoDistBinomialStDev()
{
    Console.WriteLine("Demo Binomial Distribution: Standard Deviation");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p).stdev(); " +
        " p={0}, n={1}" + "\"" + ">", p, n);

    Single Res01 = sreal.dist_binomial(n, p).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).stdev();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Skewness
public static void DemoDistBinomialSkewness()
{
    Console.WriteLine("Demo Binomial Distribution: Skewness");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p).skewness(); " +
        " p={0}, n={1}" + "\"" + ">", p, n);

    Single Res01 = sreal.dist_binomial(n, p).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).skewness();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Kurtosis
public static void DemoDistBinomialKurtosis()
{
    Console.WriteLine("Demo Binomial Distribution: Kurtosis");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p).kurtosis(); " +
        " p={0}, n={1}" + "\"" + ">", p, n);
    Single Res01 = sreal.dist_binomial(n, p).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).kurtosis();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region KurtosisExcess
public static void DemoDistBinomialKurtosisExcess()
{
    Console.WriteLine("Demo Binomial Distribution: Kurtosis Excess");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p).kurtosis_excess(); " +
        " p={0}, n={1}" + "\"" + ">", p, n);
    Single Res01 = sreal.dist_binomial(n, p).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).kurtosis_excess();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistBinomialSupportLowerEndpoint()
{
    Console.WriteLine("Demo Binomial Distribution: Support, Lower Endpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p)" +
        ".support_lower_endpoint();  p={0}, n={1}" + "\"" + ">", p, n);
    Single Res01 = sreal.dist_binomial(n, p).support_lower_endpoint();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).support_lower_endpoint();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).support_lower_endpoint();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).support_lower_endpoint();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).support_lower_endpoint();
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).support_lower_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportUpperEndpoint
public static void DemoDistBinomialSupportUpperEndpoint()
{
    Console.WriteLine("Demo Binomial Distribution: Support, Upper Endpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p)" +
        ".support_upper_endpoint();  p={0}, n={1}" + "\"" + ">", p, n);
    Single Res01 = sreal.dist_binomial(n, p).support_upper_endpoint();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).support_upper_endpoint();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).support_upper_endpoint();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).support_upper_endpoint();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).support_upper_endpoint();
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).support_upper_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistBinomialRangeLowerEndpoint()
{
    Console.WriteLine("Demo Binomial Distribution: Range, Lower Endpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p)" +
        ".range_lower_endpoint();  p={0}, n={1}" + "\"" + ">", p, n);
    Single Res01 = sreal.dist_binomial(n, p).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).range_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeUpperEndpoint
public static void DemoDistBinomialRangeUpperEndpoint()
{
    Console.WriteLine("Demo Binomial Distribution: Range, Upper Endpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var n in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_binomial(n, p)" +
        ".range_upper_endpoint();  p={0}, n={1}" + "\"" + ">", p, n);
    Single Res01 = sreal.dist_binomial(n, p).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_binomial(n, p).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_binomial(n, p).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_binomial(n, p).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_binomial(n, p).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_binomial(n, p).range_upper_endpoint();
    Console.WriteLine("mreal: {0}", Res06);
#endif

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

