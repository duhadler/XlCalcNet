
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
    DemoDistChi2NcPdf();
    DemoDistChi2NcCdf();
    DemoDistChi2NcSurvivalFunction();
    DemoDistChi2NcHazardFunction();
    DemoDistChi2NcCumulativeHazardFunction();
    DemoDistChi2NcQuantileFunction();
    DemoDistChi2NcInverseSurvivalFunction();
    DemoDistChi2NcMode();
    DemoDistChi2NcMedian();
    DemoDistChi2NcMean();
    DemoDistChi2NcVariance();
    DemoDistChi2NcStDev();
    DemoDistChi2NcSkewness();
    DemoDistChi2NcKurtosis();
    DemoDistChi2NcKurtosisExcess();
    DemoDistChi2NcSupportLowerEndpoint();
    DemoDistChi2NcSupportUpperEndpoint();
    DemoDistChi2NcRangeLowerEndpoint();
    DemoDistChi2NcRangeUpperEndpoint();
}


#region Demo DistChi2Nc

// n -> n
// lambda1 -> lambda1

#region Pdf
public static void DemoDistChi2NcPdf()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Pdf");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1); n={0}, lambda1={1}" 
        + "\"" + ">", n, lambda1);

    foreach (var x in new[] { 0.01, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2_nc(n, lambda1).pdf(x); " 
        + "n={0}, lambda1={1}, x={2}" + "\"" + ">", n, lambda1, x);

    Double Res00 = math53.chi2_nc_pdf(n, lambda1, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).pdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).pdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).pdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).pdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).pdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).pdf(x);
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
public static void DemoDistChi2NcCdf()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Cdf");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1); n={0}, lambda1={1}" 
        + "\"" + ">", n, lambda1);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2_nc(n, lambda1).cdf(x); " 
        + "n={0}, lambda1={1}, x={2}" + "\"" + ">", n, lambda1, x);

    Double Res00 = math53.chi2_nc_cdf(n, lambda1, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).cdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).cdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).cdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).cdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).cdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).cdf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // lambda1, n
}
#endregion

#region Survival Function
public static void DemoDistChi2NcSurvivalFunction()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Survival Function");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1); n={0}, lambda1={1}" 
        + "\"" + ">", n, lambda1);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2_nc(n, lambda1).sf(x); " 
        + "n={0}, lambda1={1}, x={2}" + "\"" + ">", n, lambda1, x);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).sf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).sf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).sf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).sf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).sf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).sf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // lambda1, n
}
#endregion

#region Hazard Function

public static void DemoDistChi2NcHazardFunction()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Hazard Function");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1); n={0}, lambda1={1}" 
        + "\"" + ">", n, lambda1);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2_nc(n, lambda1).hf(x); " 
        + "n={0}, lambda1={1}, x={2}" + "\"" + ">", n, lambda1, x);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).hf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).hf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).hf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).hf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).hf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).hf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // lambda1, n
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistChi2NcCumulativeHazardFunction()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Cumulative Hazard Function");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1); n={0}, lambda1={1}" 
        + "\"" + ">", n, lambda1);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2_nc(n, lambda1).chf(x); " 
        + "n={0}, lambda1={1}, x={2}" + "\"" + ">", n, lambda1, x);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).chf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).chf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).chf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).chf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).chf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).chf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // lambda1, n
}
#endregion

#region Quantile Function
public static void DemoDistChi2NcQuantileFunction()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Quantile Function");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1); n={0}, lambda1={1}" 
        + "\"" + ">", n, lambda1);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2_nc(n, lambda1).qtf(q); " + 
        "n={0}, lambda1={1}, q={2}" + "\"" + ">", n, lambda1, q);

    Double Res00 = math53.chi2_nc_qtf(n, lambda1, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // lambda1, n
}
#endregion

#region Inverse Survival Function
public static void DemoDistChi2NcInverseSurvivalFunction()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Inverse Quantile Function");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1); n={0}, lambda1={1}" 
        + "\"" + ">", n, lambda1);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2_nc(n, lambda1).isf(q); " + 
        "n={0}, lambda1={1}, q={2}" + "\"" + ">", n, lambda1, q);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).isf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // lambda1, n
}
#endregion

#region Mode
public static void DemoDistChi2NcMode()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Mode");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1).mode(); " +
        " n={0}, lambda1={1}" + "\"" + ">", n, lambda1);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).mode();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Median
public static void DemoDistChi2NcMedian()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Median");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1).median(); " +
        " n={0}, lambda1={1}" + "\"" + ">", n, lambda1);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).median();
    Console.WriteLine(" mreal: {0}", Res06);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Mean
public static void DemoDistChi2NcMean()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Mean");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1).mean(); " +
        " n={0}, lambda1={1}" + "\"" + ">", n, lambda1);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).mean();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Variance
public static void DemoDistChi2NcVariance()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Variance");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1).variance(); " +
        " n={0}, lambda1={1}" + "\"" + ">", n, lambda1);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).variance();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region StDev
public static void DemoDistChi2NcStDev()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Standard Deviation");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1).stdev(); " +
        " n={0}, lambda1={1}" + "\"" + ">", n, lambda1);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).stdev();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Skewness
public static void DemoDistChi2NcSkewness()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Skewness");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1).skewness(); " +
        " n={0}, lambda1={1}" + "\"" + ">", n, lambda1);

    Single Res01 = sreal.dist_chi2_nc(n, lambda1).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).skewness();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Kurtosis
public static void DemoDistChi2NcKurtosis()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Kurtosis");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1).kurtosis(); " +
        " n={0}, lambda1={1}" + "\"" + ">", n, lambda1);
    Single Res01 = sreal.dist_chi2_nc(n, lambda1).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).kurtosis();
    Console.WriteLine(" mreal: {0}", Res06);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region KurtosisExcess
public static void DemoDistChi2NcKurtosisExcess()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Kurtosis Excess");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1).kurtosis_excess(); " +
        " n={0}, lambda1={1}" + "\"" + ">", n, lambda1);
    Single Res01 = sreal.dist_chi2_nc(n, lambda1).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).kurtosis_excess();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistChi2NcSupportLowerEndpoint()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Support, Lower Endpoint");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1)" +
        ".support_lower_endpoint();  n={0}, lambda1={1}" + "\"" + ">", n, lambda1);
    Single Res01 = sreal.dist_chi2_nc(n, lambda1).support_lower_endpoint();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).support_lower_endpoint();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).support_lower_endpoint();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).support_lower_endpoint();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).support_lower_endpoint();
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).support_lower_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportUpperEndpoint
public static void DemoDistChi2NcSupportUpperEndpoint()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Support, Upper Endpoint");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1)" +
        ".support_upper_endpoint();  n={0}, lambda1={1}" + "\"" + ">", n, lambda1);
    Single Res01 = sreal.dist_chi2_nc(n, lambda1).support_upper_endpoint();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).support_upper_endpoint();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).support_upper_endpoint();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).support_upper_endpoint();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).support_upper_endpoint();
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).support_upper_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistChi2NcRangeLowerEndpoint()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Range, Lower Endpoint");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1)" +
        ".range_lower_endpoint();  n={0}, lambda1={1}" + "\"" + ">", n, lambda1);
    Single Res01 = sreal.dist_chi2_nc(n, lambda1).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).range_lower_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeUpperEndpoint
public static void DemoDistChi2NcRangeUpperEndpoint()
{
    Console.WriteLine("Demo Chi2Nc Distribution: Range, Upper Endpoint");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var lambda1 in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2_nc(n, lambda1)" +
        ".range_upper_endpoint();  n={0}, lambda1={1}" + "\"" + ">", n, lambda1);
    Single Res01 = sreal.dist_chi2_nc(n, lambda1).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2_nc(n, lambda1).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2_nc(n, lambda1).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2_nc(n, lambda1).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2_nc(n, lambda1).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2_nc(n, lambda1).range_upper_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
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

