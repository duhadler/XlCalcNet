
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
    DemoDistHypergeometricPmf();
    DemoDistHypergeometricCdf();
    DemoDistHypergeometricSurvivalFunction();
    DemoDistHypergeometricHazardFunction();
    DemoDistHypergeometricCumulativeHazardFunction();
    DemoDistHypergeometricQuantileFunction();
    DemoDistHypergeometricInverseSurvivalFunction();
    DemoDistHypergeometricMode();
    DemoDistHypergeometricMedian();
    DemoDistHypergeometricMean();
    DemoDistHypergeometricVariance();
    DemoDistHypergeometricStDev();
    DemoDistHypergeometricSkewness();
    DemoDistHypergeometricKurtosis();
    DemoDistHypergeometricKurtosisExcess();
    DemoDistHypergeometricSupportLowerEndpoint();
    DemoDistHypergeometricSupportUpperEndpoint();
    DemoDistHypergeometricRangeLowerEndpoint();
    DemoDistHypergeometricRangeUpperEndpoint();
}


#region Demo DistHypergeometric

 // r=defective/failures/success, n=trials/draws, N=total population.

#region Pmf
public static void DemoDistHypergeometricPmf()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Pmf");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    foreach (var k in new[] { 20, 40, 60 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hypergeometric(r, n, N).pmf(k); " 
        + "r={0}, n={1}, k={2}" + "\"" + ">", r, n, k);

    Double Res00 = math53.hypergeometric_pmf(r, n, N, k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).pmf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).pmf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).pmf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).pmf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).pmf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).pmf(k);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Cdf
public static void DemoDistHypergeometricCdf()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Cdf");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    foreach (var k in new[] { 20, 40, 60 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hypergeometric(r, n, N).cdf(k); " 
        + "r={0}, n={1}, k={2}" + "\"" + ">", r, n, k);

    Double Res00 = math53.hypergeometric_cdf(r, n, N, k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).cdf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).cdf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).cdf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).cdf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).cdf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).cdf(k);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }}} // n, r
}
#endregion

#region Survival Function
public static void DemoDistHypergeometricSurvivalFunction()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Survival Function");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    foreach (var k in new[] { 20, 40, 60 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hypergeometric(r, n, N).sf(k); " 
        + "r={0}, n={1}, k={2}" + "\"" + ">", r, n, k);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).sf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).sf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).sf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).sf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).sf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).sf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }}} // n, r
}
#endregion

#region Hazard Function

public static void DemoDistHypergeometricHazardFunction()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Hazard Function");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    foreach (var k in new[] { 20, 40, 60 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hypergeometric(r, n, N).hf(k); " 
        + "r={0}, n={1}, k={2}" + "\"" + ">", r, n, k);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).hf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).hf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).hf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).hf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).hf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).hf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }}} // n, r
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistHypergeometricCumulativeHazardFunction()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Cumulative Hazard Function");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    foreach (var k in new[] { 20, 40, 60 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hypergeometric(r, n, N).chf(k); " 
        + "r={0}, n={1}, k={2}" + "\"" + ">", r, n, k);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).chf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).chf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).chf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).chf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).chf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).chf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }}} // n, r
}
#endregion

#region Quantile Function
public static void DemoDistHypergeometricQuantileFunction()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Quantile Function");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hypergeometric(r, n, N).qtf(q); " + 
        "r={0}, n={1}, q={2}" + "\"" + ">", r, n, q);

    Double Res00 = math53.hypergeometric_qtf(r, n, N, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }}} // n, r
}
#endregion

#region Inverse Survival Function
public static void DemoDistHypergeometricInverseSurvivalFunction()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Inverse Quantile Function");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hypergeometric(r, n, N).isf(q); " + 
        "r={0}, n={1}, q={2}" + "\"" + ">", r, n, q);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).isf(q);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }}} // n, r
}
#endregion

#region Mode
public static void DemoDistHypergeometricMode()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Mode");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).mode();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Median
public static void DemoDistHypergeometricMedian()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Median");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).median();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Mean
public static void DemoDistHypergeometricMean()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Mean");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).mean();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Variance
public static void DemoDistHypergeometricVariance()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Variance");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).variance();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region StDev
public static void DemoDistHypergeometricStDev()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Standard Deviation");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).stdev();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Skewness
public static void DemoDistHypergeometricSkewness()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Skewness");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);

    Single Res01 = sreal.dist_hypergeometric(r, n, N).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).skewness();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Kurtosis
public static void DemoDistHypergeometricKurtosis()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Kurtosis");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);
    Single Res01 = sreal.dist_hypergeometric(r, n, N).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).kurtosis();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region KurtosisExcess
public static void DemoDistHypergeometricKurtosisExcess()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Kurtosis Excess");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);
    Single Res01 = sreal.dist_hypergeometric(r, n, N).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_hypergeometric(r, n, N).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hypergeometric(r, n, N).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hypergeometric(r, n, N).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hypergeometric(r, n, N).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hypergeometric(r, n, N).kurtosis_excess();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistHypergeometricSupportLowerEndpoint()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Support, Lower Endpoint");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N).support_lower_endpoint(); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);
    Single Res01L = sreal.dist_hypergeometric(r, n, N).support_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_hypergeometric(r, n, N).support_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_hypergeometric(r, n, N).support_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_hypergeometric(r, n, N).support_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_hypergeometric(r, n, N).support_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_hypergeometric(r, n, N).support_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region SupportUpperEndpoint
public static void DemoDistHypergeometricSupportUpperEndpoint()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Support, Upper Endpoint");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N).support_upper_endpoint(); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);
    Single Res01R = sreal.dist_hypergeometric(r, n, N).support_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_hypergeometric(r, n, N).support_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_hypergeometric(r, n, N).support_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_hypergeometric(r, n, N).support_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_hypergeometric(r, n, N).support_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_hypergeometric(r, n, N).support_upper_endpoint();
    Console.WriteLine("mreal: {0}", Res06R);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistHypergeometricRangeLowerEndpoint()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Range, Lower Endpoint");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N).range_lower_endpoint(); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);
    Single Res01L = sreal.dist_hypergeometric(r, n, N).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_hypergeometric(r, n, N).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_hypergeometric(r, n, N).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_hypergeometric(r, n, N).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_hypergeometric(r, n, N).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_hypergeometric(r, n, N).range_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region RangeUpperEndpoint
public static void DemoDistHypergeometricRangeUpperEndpoint()
{
    Console.WriteLine("Demo Hypergeometric Distribution: Range, Upper Endpoint");
    foreach (ulong r in new[] { 50, 100, 250 }) {
    foreach (ulong n in new[] { 50, 100, 250 }) {
    foreach (ulong N in new[] { 500 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_hypergeometric(r, n, N).range_upper_endpoint(); r={0}, n={1}, N={2}" 
        + "\"" + ">", r, n, N);
    Single Res01R = sreal.dist_hypergeometric(r, n, N).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_hypergeometric(r, n, N).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_hypergeometric(r, n, N).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_hypergeometric(r, n, N).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_hypergeometric(r, n, N).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_hypergeometric(r, n, N).range_upper_endpoint();
    Console.WriteLine("mreal: {0}", Res06R);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
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

