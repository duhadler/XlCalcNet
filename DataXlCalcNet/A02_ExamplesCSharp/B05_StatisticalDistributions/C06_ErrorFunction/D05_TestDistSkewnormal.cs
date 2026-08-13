
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
    DemoDistSkewnormalPdf();
    DemoDistSkewnormalCdf();
    DemoDistSkewnormalSurvivalFunction();
    DemoDistSkewnormalHazardFunction();
    DemoDistSkewnormalCumulativeHazardFunction();
    DemoDistSkewnormalQuantileFunction();
    DemoDistSkewnormalInverseSurvivalFunction();
    DemoDistSkewnormalMode();
    DemoDistSkewnormalMedian();
    DemoDistSkewnormalMean();
    DemoDistSkewnormalVariance();
    DemoDistSkewnormalStDev();
    DemoDistSkewnormalSkewness();
    DemoDistSkewnormalKurtosis();
    DemoDistSkewnormalKurtosisExcess();
    DemoDistSkewnormalSupportLowerEndpoint();
    DemoDistSkewnormalSupportUpperEndpoint();
    DemoDistSkewnormalRangeLowerEndpoint();
    DemoDistSkewnormalRangeUpperEndpoint();
}


#region Demo DistSkewnormal


#region Pdf
public static void DemoDistSkewnormalPdf()
{
    Console.WriteLine("Demo Skewnormal Distribution: Pdf");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_skewnormal(a, b, c).pdf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Double Res00 = math53.skewnormal_pdf(a, b, c, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_skewnormal(a, b, c).pdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).pdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).pdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).pdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).pdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).pdf(x);
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
public static void DemoDistSkewnormalCdf()
{
    Console.WriteLine("Demo Skewnormal Distribution: Cdf");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_skewnormal(a, b, c).cdf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Double Res00 = math53.skewnormal_cdf(a, b, c, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_skewnormal(a, b, c).cdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).cdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).cdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).cdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).cdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).cdf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }}} // b, a
}
#endregion

#region Survival Function
public static void DemoDistSkewnormalSurvivalFunction()
{
    Console.WriteLine("Demo Skewnormal Distribution: Survival Function");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_skewnormal(a, b, c).sf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Single Res01 = sreal.dist_skewnormal(a, b, c).sf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).sf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).sf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).sf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).sf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).sf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }}} // b, a
}
#endregion

#region Hazard Function

public static void DemoDistSkewnormalHazardFunction()
{
    Console.WriteLine("Demo Skewnormal Distribution: Hazard Function");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_skewnormal(a, b, c).hf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Single Res01 = sreal.dist_skewnormal(a, b, c).hf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).hf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).hf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).hf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).hf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).hf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }}} // b, a
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistSkewnormalCumulativeHazardFunction()
{
    Console.WriteLine("Demo Skewnormal Distribution: Cumulative Hazard Function");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_skewnormal(a, b, c).chf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Single Res01 = sreal.dist_skewnormal(a, b, c).chf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).chf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).chf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).chf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).chf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).chf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }}} // b, a
}
#endregion

#region Quantile Function
public static void DemoDistSkewnormalQuantileFunction()
{
    Console.WriteLine("Demo Skewnormal Distribution: Quantile Function");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_skewnormal(a, b, c).qtf(q); " + 
        "a={0}, b={1}, q={2}" + "\"" + ">", a, b, q);

    Double Res00 = math53.skewnormal_qtf(a, b, c, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_skewnormal(a, b, c).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }}} // b, a
}
#endregion

#region Inverse Survival Function
public static void DemoDistSkewnormalInverseSurvivalFunction()
{
    Console.WriteLine("Demo Skewnormal Distribution: Inverse Quantile Function");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_skewnormal(a, b, c).isf(q); " + 
        "a={0}, b={1}, q={2}" + "\"" + ">", a, b, q);

    Single Res01 = sreal.dist_skewnormal(a, b, c).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).isf(q);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }}} // b, a
}
#endregion

#region Mode
public static void DemoDistSkewnormalMode()
{
    Console.WriteLine("Demo Skewnormal Distribution: Mode");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    Single Res01 = sreal.dist_skewnormal(a, b, c).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).mode();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Median
public static void DemoDistSkewnormalMedian()
{
    Console.WriteLine("Demo Skewnormal Distribution: Median");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    Single Res01 = sreal.dist_skewnormal(a, b, c).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).median();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Mean
public static void DemoDistSkewnormalMean()
{
    Console.WriteLine("Demo Skewnormal Distribution: Mean");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    Single Res01 = sreal.dist_skewnormal(a, b, c).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).mean();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Variance
public static void DemoDistSkewnormalVariance()
{
    Console.WriteLine("Demo Skewnormal Distribution: Variance");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    Single Res01 = sreal.dist_skewnormal(a, b, c).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).variance();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region StDev
public static void DemoDistSkewnormalStDev()
{
    Console.WriteLine("Demo Skewnormal Distribution: Standard Deviation");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    Single Res01 = sreal.dist_skewnormal(a, b, c).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).stdev();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Skewness
public static void DemoDistSkewnormalSkewness()
{
    Console.WriteLine("Demo Skewnormal Distribution: Skewness");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);

    Single Res01 = sreal.dist_skewnormal(a, b, c).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).skewness();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Kurtosis
public static void DemoDistSkewnormalKurtosis()
{
    Console.WriteLine("Demo Skewnormal Distribution: Kurtosis");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);
    Single Res01 = sreal.dist_skewnormal(a, b, c).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).kurtosis();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region KurtosisExcess
public static void DemoDistSkewnormalKurtosisExcess()
{
    Console.WriteLine("Demo Skewnormal Distribution: Kurtosis Excess");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);
    Single Res01 = sreal.dist_skewnormal(a, b, c).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_skewnormal(a, b, c).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_skewnormal(a, b, c).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_skewnormal(a, b, c).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_skewnormal(a, b, c).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_skewnormal(a, b, c).kurtosis_excess();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistSkewnormalSupportLowerEndpoint()
{
    Console.WriteLine("Demo Skewnormal Distribution: SupportLowerEndpoint");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c).support_lower_endpoint(); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);
    Single Res01L = sreal.dist_skewnormal(a, b, c).support_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_skewnormal(a, b, c).support_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_skewnormal(a, b, c).support_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_skewnormal(a, b, c).support_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_skewnormal(a, b, c).support_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_skewnormal(a, b, c).support_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region SupportUpperEndpoint
public static void DemoDistSkewnormalSupportUpperEndpoint()
{
    Console.WriteLine("Demo Skewnormal Distribution: SupportUpperEndpoint");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c).support_upper_endpoint(); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);
    Single Res01R = sreal.dist_skewnormal(a, b, c).support_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_skewnormal(a, b, c).support_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_skewnormal(a, b, c).support_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_skewnormal(a, b, c).support_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_skewnormal(a, b, c).support_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_skewnormal(a, b, c).support_upper_endpoint();
    Console.WriteLine("mreal: {0}", Res06R);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion




#region RangeLowerEndpoint
public static void DemoDistSkewnormalRangeLowerEndpoint()
{
    Console.WriteLine("Demo Skewnormal Distribution: RangeLowerEndpoint");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c).range_lower_endpoint(); a={0}, b={1}, c={2}" 
        + "\"" + ">", a, b, c);
    Single Res01L = sreal.dist_skewnormal(a, b, c).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_skewnormal(a, b, c).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_skewnormal(a, b, c).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_skewnormal(a, b, c).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_skewnormal(a, b, c).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_skewnormal(a, b, c).range_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    }}}
}
#endregion


#region RangeUpperEndpoint
public static void DemoDistSkewnormalRangeUpperEndpoint()
{
    Console.WriteLine("Demo Skewnormal Distribution: RangeUpperEndpoint");
    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var c in new[] { b + 15.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_skewnormal(a, b, c).range_upper_endpoint(); a={0}, b={1}, c={2}"
        + "\"" + ">", a, b, c);
    Single Res01R = sreal.dist_skewnormal(a, b, c).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_skewnormal(a, b, c).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_skewnormal(a, b, c).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_skewnormal(a, b, c).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_skewnormal(a, b, c).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_skewnormal(a, b, c).range_upper_endpoint();
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

