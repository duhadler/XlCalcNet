
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
    DemoDistArcsinePdf();
    DemoDistArcsineCdf();
    DemoDistArcsineSurvivalFunction();
    DemoDistArcsineHazardFunction();
    DemoDistArcsineCumulativeHazardFunction();
    DemoDistArcsineQuantileFunction();
    DemoDistArcsineInverseSurvivalFunction();
    DemoDistArcsineMode();
    DemoDistArcsineMedian();
    DemoDistArcsineMean();
    DemoDistArcsineVariance();
    DemoDistArcsineStDev();
    DemoDistArcsineSkewness();
    DemoDistArcsineKurtosis();
    DemoDistArcsineKurtosisExcess();
    DemoDistArcsineSupportLowerEndpoint();
    DemoDistArcsineSupportUpperEndpoint();
    DemoDistArcsineRangeLowerEndpoint();
    DemoDistArcsineRangeUpperEndpoint();
}


#region Demo DistArcsine


#region Pdf
public static void DemoDistArcsinePdf()
{
    Console.WriteLine("Demo Arcsine Distribution: Pdf");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b); a={0}, b={1}" 
        + "\"" + ">", a, b);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_arcsine(a, b).pdf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Double Res00 = math53.arcsine_pdf(a, b, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_arcsine(a, b).pdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).pdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).pdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).pdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).pdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).pdf(x);
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
public static void DemoDistArcsineCdf()
{
    Console.WriteLine("Demo Arcsine Distribution: Cdf");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b); a={0}, b={1}" 
        + "\"" + ">", a, b);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_arcsine(a, b).cdf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Double Res00 = math53.arcsine_cdf(a, b, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_arcsine(a, b).cdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).cdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).cdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).cdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).cdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).cdf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // b, a
}
#endregion

#region Survival Function
public static void DemoDistArcsineSurvivalFunction()
{
    Console.WriteLine("Demo Arcsine Distribution: Survival Function");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b); a={0}, b={1}" 
        + "\"" + ">", a, b);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_arcsine(a, b).sf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Single Res01 = sreal.dist_arcsine(a, b).sf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).sf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).sf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).sf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).sf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).sf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // b, a
}
#endregion

#region Hazard Function

public static void DemoDistArcsineHazardFunction()
{
    Console.WriteLine("Demo Arcsine Distribution: Hazard Function");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b); a={0}, b={1}" 
        + "\"" + ">", a, b);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_arcsine(a, b).hf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Single Res01 = sreal.dist_arcsine(a, b).hf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).hf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).hf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).hf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).hf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).hf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // b, a
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistArcsineCumulativeHazardFunction()
{
    Console.WriteLine("Demo Arcsine Distribution: Cumulative Hazard Function");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b); a={0}, b={1}" 
        + "\"" + ">", a, b);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_arcsine(a, b).chf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Single Res01 = sreal.dist_arcsine(a, b).chf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).chf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).chf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).chf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).chf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).chf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // b, a
}
#endregion

#region Quantile Function
public static void DemoDistArcsineQuantileFunction()
{
    Console.WriteLine("Demo Arcsine Distribution: Quantile Function");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b); a={0}, b={1}" 
        + "\"" + ">", a, b);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_arcsine(a, b).qtf(q); " + 
        "a={0}, b={1}, q={2}" + "\"" + ">", a, b, q);

    Double Res00 = math53.arcsine_qtf(a, b, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_arcsine(a, b).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // b, a
}
#endregion

#region Inverse Survival Function
public static void DemoDistArcsineInverseSurvivalFunction()
{
    Console.WriteLine("Demo Arcsine Distribution: Inverse Quantile Function");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b); a={0}, b={1}" 
        + "\"" + ">", a, b);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_arcsine(a, b).isf(q); " + 
        "a={0}, b={1}, q={2}" + "\"" + ">", a, b, q);

    Single Res01 = sreal.dist_arcsine(a, b).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).isf(q);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }} // b, a
}
#endregion

#region Mode
public static void DemoDistArcsineMode()
{
    Console.WriteLine("Demo Arcsine Distribution: Mode");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b).mode(); " +
        " a={0}, b={1}" + "\"" + ">", a, b);

    Single Res01 = sreal.dist_arcsine(a, b).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).mode();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Median
public static void DemoDistArcsineMedian()
{
    Console.WriteLine("Demo Arcsine Distribution: Median");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b).median(); " +
        " a={0}, b={1}" + "\"" + ">", a, b);

    Single Res01 = sreal.dist_arcsine(a, b).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).median();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Mean
public static void DemoDistArcsineMean()
{
    Console.WriteLine("Demo Arcsine Distribution: Mean");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b).mean(); " +
        " a={0}, b={1}" + "\"" + ">", a, b);

    Single Res01 = sreal.dist_arcsine(a, b).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).mean();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Variance
public static void DemoDistArcsineVariance()
{
    Console.WriteLine("Demo Arcsine Distribution: Variance");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b).variance(); " +
        " a={0}, b={1}" + "\"" + ">", a, b);

    Single Res01 = sreal.dist_arcsine(a, b).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).variance();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region StDev
public static void DemoDistArcsineStDev()
{
    Console.WriteLine("Demo Arcsine Distribution: Standard Deviation");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b).stdev(); " +
        " a={0}, b={1}" + "\"" + ">", a, b);

    Single Res01 = sreal.dist_arcsine(a, b).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).stdev();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Skewness
public static void DemoDistArcsineSkewness()
{
    Console.WriteLine("Demo Arcsine Distribution: Skewness");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b).skewness(); " +
        " a={0}, b={1}" + "\"" + ">", a, b);

    Single Res01 = sreal.dist_arcsine(a, b).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).skewness();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region Kurtosis
public static void DemoDistArcsineKurtosis()
{
    Console.WriteLine("Demo Arcsine Distribution: Kurtosis");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b).kurtosis(); " +
        " a={0}, b={1}" + "\"" + ">", a, b);
    Single Res01 = sreal.dist_arcsine(a, b).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).kurtosis();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region KurtosisExcess
public static void DemoDistArcsineKurtosisExcess()
{
    Console.WriteLine("Demo Arcsine Distribution: Kurtosis Excess");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b).kurtosis_excess(); " +
        " a={0}, b={1}" + "\"" + ">", a, b);
    Single Res01 = sreal.dist_arcsine(a, b).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).kurtosis_excess();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistArcsineSupportLowerEndpoint()
{
    Console.WriteLine("Demo Arcsine Distribution: Support, Lower Endpoint");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b)" +
        ".support_lower_endpoint();  a={0}, b={1}" + "\"" + ">", a, b);
    Single Res01 = sreal.dist_arcsine(a, b).support_lower_endpoint();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).support_lower_endpoint();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).support_lower_endpoint();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).support_lower_endpoint();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).support_lower_endpoint();
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).support_lower_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region SupportUpperEndpoint
public static void DemoDistArcsineSupportUpperEndpoint()
{
    Console.WriteLine("Demo Arcsine Distribution: Support, Upper Endpoint");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b)" +
        ".support_upper_endpoint();  a={0}, b={1}" + "\"" + ">", a, b);
    Single Res01 = sreal.dist_arcsine(a, b).support_upper_endpoint();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).support_upper_endpoint();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).support_upper_endpoint();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).support_upper_endpoint();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).support_upper_endpoint();
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).support_upper_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistArcsineRangeLowerEndpoint()
{
    Console.WriteLine("Demo Arcsine Distribution: Range, Lower Endpoint");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b)" +
        ".range_lower_endpoint();  a={0}, b={1}" + "\"" + ">", a, b);
    Single Res01 = sreal.dist_arcsine(a, b).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).range_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}
}
#endregion

#region RangeUpperEndpoint
public static void DemoDistArcsineRangeUpperEndpoint()
{
    Console.WriteLine("Demo Arcsine Distribution: Range, Upper Endpoint");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_arcsine(a, b)" +
        ".range_upper_endpoint();  a={0}, b={1}" + "\"" + ">", a, b);
    Single Res01 = sreal.dist_arcsine(a, b).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_arcsine(a, b).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_arcsine(a, b).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_arcsine(a, b).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_arcsine(a, b).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_arcsine(a, b).range_upper_endpoint();
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

