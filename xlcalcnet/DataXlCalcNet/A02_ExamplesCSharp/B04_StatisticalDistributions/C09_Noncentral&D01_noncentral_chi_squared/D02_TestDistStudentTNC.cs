
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
    DemoDistStudentTNcPdf();
    DemoDistStudentTNcCdf();
    DemoDistStudentTNcSurvivalFunction();
    DemoDistStudentTNcHazardFunction();
    DemoDistStudentTNcCumulativeHazardFunction();
    DemoDistStudentTNcQuantileFunction();
    DemoDistStudentTNcInverseSurvivalFunction();
    DemoDistStudentTNcMode();
    DemoDistStudentTNcMedian();
    DemoDistStudentTNcMean();
    DemoDistStudentTNcVariance();
    DemoDistStudentTNcStDev();
    DemoDistStudentTNcSkewness();
    DemoDistStudentTNcKurtosis();
    DemoDistStudentTNcKurtosisExcess();
    DemoDistStudentTNcSupportLowerEndpoint();
    DemoDistStudentTNcSupportUpperEndpoint();
    DemoDistStudentTNcRangeLowerEndpoint();
    DemoDistStudentTNcRangeUpperEndpoint();
}


#region Demo DistStudentTNc


#region Pdf
public static void DemoDistStudentTNcPdf()
{
    Console.WriteLine("Demo StudentTNc Distribution: Pdf");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta); n={0}, delta={1}" 
        + "\"" + ">", n, delta);

    foreach (var x in new[] { 0.01, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t_nc(n, delta).pdf(x); " 
        + "n={0}, delta={1}, x={2}" + "\"" + ">", n, delta, x);

    Double Res00 = math53.student_t_nc_pdf(n, delta, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_student_t_nc(n, delta).pdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).pdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).pdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).pdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).pdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).pdf(x);
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
public static void DemoDistStudentTNcCdf()
{
    Console.WriteLine("Demo StudentTNc Distribution: Cdf");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta); n={0}, delta={1}" 
        + "\"" + ">", n, delta);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t_nc(n, delta).cdf(x); " 
        + "n={0}, delta={1}, x={2}" + "\"" + ">", n, delta, x);

    Double Res00 = math53.student_t_nc_cdf(n, delta, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_student_t_nc(n, delta).cdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).cdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).cdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).cdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).cdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).cdf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // delta, n
}
#endregion

#region Survival Function
public static void DemoDistStudentTNcSurvivalFunction()
{
    Console.WriteLine("Demo StudentTNc Distribution: Survival Function");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta); n={0}, delta={1}" 
        + "\"" + ">", n, delta);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t_nc(n, delta).sf(x); " 
        + "n={0}, delta={1}, x={2}" + "\"" + ">", n, delta, x);

    Single Res01 = sreal.dist_student_t_nc(n, delta).sf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).sf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).sf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).sf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).sf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).sf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // delta, n
}
#endregion

#region Hazard Function

public static void DemoDistStudentTNcHazardFunction()
{
    Console.WriteLine("Demo StudentTNc Distribution: Hazard Function");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta); n={0}, delta={1}" 
        + "\"" + ">", n, delta);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t_nc(n, delta).hf(x); " 
        + "n={0}, delta={1}, x={2}" + "\"" + ">", n, delta, x);

    Single Res01 = sreal.dist_student_t_nc(n, delta).hf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).hf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).hf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).hf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).hf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).hf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // delta, n
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistStudentTNcCumulativeHazardFunction()
{
    Console.WriteLine("Demo StudentTNc Distribution: Cumulative Hazard Function");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta); n={0}, delta={1}" 
        + "\"" + ">", n, delta);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t_nc(n, delta).chf(x); " 
        + "n={0}, delta={1}, x={2}" + "\"" + ">", n, delta, x);

    Single Res01 = sreal.dist_student_t_nc(n, delta).chf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).chf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).chf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).chf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).chf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).chf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // delta, n
}
#endregion

#region Quantile Function
public static void DemoDistStudentTNcQuantileFunction()
{
    Console.WriteLine("Demo StudentTNc Distribution: Quantile Function");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta); n={0}, delta={1}" 
        + "\"" + ">", n, delta);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t_nc(n, delta).qtf(q); " + 
        "n={0}, delta={1}, q={2}" + "\"" + ">", n, delta, q);

    Double Res00 = math53.student_t_nc_qtf(n, delta, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_student_t_nc(n, delta).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // delta, n
}
#endregion

#region Inverse Survival Function
public static void DemoDistStudentTNcInverseSurvivalFunction()
{
    Console.WriteLine("Demo StudentTNc Distribution: Inverse Quantile Function");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta); n={0}, delta={1}" 
        + "\"" + ">", n, delta);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t_nc(n, delta).isf(q); " + 
        "n={0}, delta={1}, q={2}" + "\"" + ">", n, delta, q);

    Single Res01 = sreal.dist_student_t_nc(n, delta).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).isf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // delta, n
}
#endregion

#region Mode
public static void DemoDistStudentTNcMode()
{
    Console.WriteLine("Demo StudentTNc Distribution: Mode");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta).mode(); " +
        " n={0}, delta={1}" + "\"" + ">", n, delta);

    Single Res01 = sreal.dist_student_t_nc(n, delta).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).mode();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Median
public static void DemoDistStudentTNcMedian()
{
    Console.WriteLine("Demo StudentTNc Distribution: Median");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta).median(); " +
        " n={0}, delta={1}" + "\"" + ">", n, delta);

    Single Res01 = sreal.dist_student_t_nc(n, delta).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).median();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Mean
public static void DemoDistStudentTNcMean()
{
    Console.WriteLine("Demo StudentTNc Distribution: Mean");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta).mean(); " +
        " n={0}, delta={1}" + "\"" + ">", n, delta);

    Single Res01 = sreal.dist_student_t_nc(n, delta).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).mean();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Variance
public static void DemoDistStudentTNcVariance()
{
    Console.WriteLine("Demo StudentTNc Distribution: Variance");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta).variance(); " +
        " n={0}, delta={1}" + "\"" + ">", n, delta);

    Single Res01 = sreal.dist_student_t_nc(n, delta).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).variance();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region StDev
public static void DemoDistStudentTNcStDev()
{
    Console.WriteLine("Demo StudentTNc Distribution: Standard Deviation");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta).stdev(); " +
        " n={0}, delta={1}" + "\"" + ">", n, delta);

    Single Res01 = sreal.dist_student_t_nc(n, delta).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).stdev();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Skewness
public static void DemoDistStudentTNcSkewness()
{
    Console.WriteLine("Demo StudentTNc Distribution: Skewness");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta).skewness(); " +
        " n={0}, delta={1}" + "\"" + ">", n, delta);

    Single Res01 = sreal.dist_student_t_nc(n, delta).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).skewness();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Kurtosis
public static void DemoDistStudentTNcKurtosis()
{
    Console.WriteLine("Demo StudentTNc Distribution: Kurtosis");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta).kurtosis(); " +
        " n={0}, delta={1}" + "\"" + ">", n, delta);
    Single Res01 = sreal.dist_student_t_nc(n, delta).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).kurtosis();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region KurtosisExcess
public static void DemoDistStudentTNcKurtosisExcess()
{
    Console.WriteLine("Demo StudentTNc Distribution: Kurtosis Excess");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta).kurtosis_excess(); " +
        " n={0}, delta={1}" + "\"" + ">", n, delta);
    Single Res01 = sreal.dist_student_t_nc(n, delta).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).kurtosis_excess();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistStudentTNcSupportLowerEndpoint()
{
    Console.WriteLine("Demo StudentTNc Distribution: Support, Lower Endpoint");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta)" +
        ".support_lower_endpoint();  n={0}, delta={1}" + "\"" + ">", n, delta);
    Single Res01 = sreal.dist_student_t_nc(n, delta).support_lower_endpoint();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).support_lower_endpoint();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).support_lower_endpoint();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).support_lower_endpoint();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).support_lower_endpoint();
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).support_lower_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportUpperEndpoint
public static void DemoDistStudentTNcSupportUpperEndpoint()
{
    Console.WriteLine("Demo StudentTNc Distribution: Support, Upper Endpoint");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta)" +
        ".support_upper_endpoint();  n={0}, delta={1}" + "\"" + ">", n, delta);
    Single Res01 = sreal.dist_student_t_nc(n, delta).support_upper_endpoint();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).support_upper_endpoint();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).support_upper_endpoint();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).support_upper_endpoint();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).support_upper_endpoint();
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).support_upper_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistStudentTNcRangeLowerEndpoint()
{
    Console.WriteLine("Demo StudentTNc Distribution: Range, Lower Endpoint");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta)" +
        ".range_lower_endpoint();  n={0}, delta={1}" + "\"" + ">", n, delta);
    Single Res01 = sreal.dist_student_t_nc(n, delta).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).range_lower_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeUpperEndpoint
public static void DemoDistStudentTNcRangeUpperEndpoint()
{
    Console.WriteLine("Demo StudentTNc Distribution: Range, Upper Endpoint");
    foreach (var n in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var delta in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t_nc(n, delta)" +
        ".range_upper_endpoint();  n={0}, delta={1}" + "\"" + ">", n, delta);
    Single Res01 = sreal.dist_student_t_nc(n, delta).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t_nc(n, delta).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t_nc(n, delta).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t_nc(n, delta).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t_nc(n, delta).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t_nc(n, delta).range_upper_endpoint();
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

