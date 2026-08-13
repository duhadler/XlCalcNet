
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
    DemoDistNegbinomialPmf();
    DemoDistNegbinomialCdf();
    DemoDistNegbinomialSurvivalFunction();
    DemoDistNegbinomialHazardFunction();
    DemoDistNegbinomialCumulativeHazardFunction();
    DemoDistNegbinomialQuantileFunction();
    DemoDistNegbinomialInverseSurvivalFunction();
    DemoDistNegbinomialMode();
    DemoDistNegbinomialMedian();
    DemoDistNegbinomialMean();
    DemoDistNegbinomialVariance();
    DemoDistNegbinomialStDev();
    DemoDistNegbinomialSkewness();
    DemoDistNegbinomialKurtosis();
    DemoDistNegbinomialKurtosisExcess();
    DemoDistNegbinomialSupportLowerEndpoint();
    DemoDistNegbinomialSupportUpperEndpoint();
    DemoDistNegbinomialRangeLowerEndpoint();
    DemoDistNegbinomialRangeUpperEndpoint();
}


#region Demo DistNegbinomial


#region Pmf
public static void DemoDistNegbinomialPmf()
{
    Console.WriteLine("Demo Negbinomial Distribution: Pmf");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p); p={0}, r={1}" 
        + "\"" + ">", p, r);

    foreach (var k in new[] { 3, 10, 20  }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_negbinomial(r, p).pmf(k); " 
        + "p={0}, r={1}, k={2}" + "\"" + ">", p, r, k);

    Double Res00 = math53.negbinomial_pmf(r, p, k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_negbinomial(r, p).pmf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).pmf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).pmf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).pmf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).pmf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).pmf(k);
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
public static void DemoDistNegbinomialCdf()
{
    Console.WriteLine("Demo Negbinomial Distribution: Cdf");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p); p={0}, r={1}" 
        + "\"" + ">", p, r);

    foreach (var k in new[] { 3, 10, 20  }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_negbinomial(r, p).cdf(k); " 
        + "p={0}, r={1}, k={2}" + "\"" + ">", p, r, k);

    Double Res00 = math53.negbinomial_cdf(r, p, k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_negbinomial(r, p).cdf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).cdf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).cdf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).cdf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).cdf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).cdf(k);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // r, p
}
#endregion

#region Survival Function
public static void DemoDistNegbinomialSurvivalFunction()
{
    Console.WriteLine("Demo Negbinomial Distribution: Survival Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p); p={0}, r={1}" 
        + "\"" + ">", p, r);

    foreach (var k in new[] { 3, 10, 20  }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_negbinomial(r, p).sf(k); " 
        + "p={0}, r={1}, k={2}" + "\"" + ">", p, r, k);

    Single Res01 = sreal.dist_negbinomial(r, p).sf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).sf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).sf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).sf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).sf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).sf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // r, p
}
#endregion

#region Hazard Function

public static void DemoDistNegbinomialHazardFunction()
{
    Console.WriteLine("Demo Negbinomial Distribution: Hazard Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p); p={0}, r={1}" 
        + "\"" + ">", p, r);

    foreach (var k in new[] { 3, 10, 20  }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_negbinomial(r, p).hf(k); " 
        + "p={0}, r={1}, k={2}" + "\"" + ">", p, r, k);

    Single Res01 = sreal.dist_negbinomial(r, p).hf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).hf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).hf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).hf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).hf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).hf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // r, p
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistNegbinomialCumulativeHazardFunction()
{
    Console.WriteLine("Demo Negbinomial Distribution: Cumulative Hazard Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p); p={0}, r={1}" 
        + "\"" + ">", p, r);

    foreach (var k in new[] { 3, 10, 20  }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_negbinomial(r, p).chf(k); " 
        + "p={0}, r={1}, k={2}" + "\"" + ">", p, r, k);

    Single Res01 = sreal.dist_negbinomial(r, p).chf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).chf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).chf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).chf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).chf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).chf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // r, p
}
#endregion

#region Quantile Function
public static void DemoDistNegbinomialQuantileFunction()
{
    Console.WriteLine("Demo Negbinomial Distribution: Quantile Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p); p={0}, r={1}" 
        + "\"" + ">", p, r);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_negbinomial(r, p).qtf(q); " + 
        "p={0}, r={1}, q={2}" + "\"" + ">", p, r, q);

    Double Res00 = math53.negbinomial_qtf(r, p, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_negbinomial(r, p).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // r, p
}
#endregion

#region Inverse Survival Function
public static void DemoDistNegbinomialInverseSurvivalFunction()
{
    Console.WriteLine("Demo Negbinomial Distribution: Inverse Quantile Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p); p={0}, r={1}" 
        + "\"" + ">", p, r);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_negbinomial(r, p).isf(q); " + 
        "p={0}, r={1}, q={2}" + "\"" + ">", p, r, q);

    Single Res01 = sreal.dist_negbinomial(r, p).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).isf(q);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    }} // r, p
}
#endregion

#region Mode
public static void DemoDistNegbinomialMode()
{
    Console.WriteLine("Demo Negbinomial Distribution: Mode");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p).mode(); " +
        " p={0}, r={1}" + "\"" + ">", p, r);

    Single Res01 = sreal.dist_negbinomial(r, p).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).mode();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Median
public static void DemoDistNegbinomialMedian()
{
    Console.WriteLine("Demo Negbinomial Distribution: Median");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p).median(); " +
        " p={0}, r={1}" + "\"" + ">", p, r);

    Single Res01 = sreal.dist_negbinomial(r, p).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).median();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Mean
public static void DemoDistNegbinomialMean()
{
    Console.WriteLine("Demo Negbinomial Distribution: Mean");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p).mean(); " +
        " p={0}, r={1}" + "\"" + ">", p, r);

    Single Res01 = sreal.dist_negbinomial(r, p).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).mean();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Variance
public static void DemoDistNegbinomialVariance()
{
    Console.WriteLine("Demo Negbinomial Distribution: Variance");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p).variance(); " +
        " p={0}, r={1}" + "\"" + ">", p, r);

    Single Res01 = sreal.dist_negbinomial(r, p).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).variance();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region StDev
public static void DemoDistNegbinomialStDev()
{
    Console.WriteLine("Demo Negbinomial Distribution: Standard Deviation");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p).stdev(); " +
        " p={0}, r={1}" + "\"" + ">", p, r);

    Single Res01 = sreal.dist_negbinomial(r, p).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).stdev();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Skewness
public static void DemoDistNegbinomialSkewness()
{
    Console.WriteLine("Demo Negbinomial Distribution: Skewness");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p).skewness(); " +
        " p={0}, r={1}" + "\"" + ">", p, r);

    Single Res01 = sreal.dist_negbinomial(r, p).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).skewness();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Kurtosis
public static void DemoDistNegbinomialKurtosis()
{
    Console.WriteLine("Demo Negbinomial Distribution: Kurtosis");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p).kurtosis(); " +
        " p={0}, r={1}" + "\"" + ">", p, r);
    Single Res01 = sreal.dist_negbinomial(r, p).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).kurtosis();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region KurtosisExcess
public static void DemoDistNegbinomialKurtosisExcess()
{
    Console.WriteLine("Demo Negbinomial Distribution: Kurtosis Excess");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p).kurtosis_excess(); " +
        " p={0}, r={1}" + "\"" + ">", p, r);
    Single Res01 = sreal.dist_negbinomial(r, p).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).kurtosis_excess();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistNegbinomialSupportLowerEndpoint()
{
    Console.WriteLine("Demo Negbinomial Distribution: Support, Lower Endpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p)" +
        ".support_lower_endpoint();  p={0}, r={1}" + "\"" + ">", p, r);
    Single Res01 = sreal.dist_negbinomial(r, p).support_lower_endpoint();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).support_lower_endpoint();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).support_lower_endpoint();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).support_lower_endpoint();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).support_lower_endpoint();
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).support_lower_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportUpperEndpoint
public static void DemoDistNegbinomialSupportUpperEndpoint()
{
    Console.WriteLine("Demo Negbinomial Distribution: Support, Upper Endpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p)" +
        ".support_upper_endpoint();  p={0}, r={1}" + "\"" + ">", p, r);
    Single Res01 = sreal.dist_negbinomial(r, p).support_upper_endpoint();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).support_upper_endpoint();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).support_upper_endpoint();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).support_upper_endpoint();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).support_upper_endpoint();
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).support_upper_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistNegbinomialRangeLowerEndpoint()
{
    Console.WriteLine("Demo Negbinomial Distribution: Range, Lower Endpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p)" +
        ".range_lower_endpoint();  p={0}, r={1}" + "\"" + ">", p, r);
    Single Res01 = sreal.dist_negbinomial(r, p).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).range_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeUpperEndpoint
public static void DemoDistNegbinomialRangeUpperEndpoint()
{
    Console.WriteLine("Demo Negbinomial Distribution: Range, Upper Endpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    foreach (var r in new[] { 5, 22, 53 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_negbinomial(r, p)" +
        ".range_upper_endpoint();  p={0}, r={1}" + "\"" + ">", p, r);
    Single Res01 = sreal.dist_negbinomial(r, p).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_negbinomial(r, p).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_negbinomial(r, p).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_negbinomial(r, p).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_negbinomial(r, p).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_negbinomial(r, p).range_upper_endpoint();
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

