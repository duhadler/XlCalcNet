
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
    DemoDistBetaNcPdf();
    DemoDistBetaNcCdf();
    DemoDistBetaNcSurvivalFunction();
    DemoDistBetaNcHazardFunction();
    DemoDistBetaNcCumulativeHazardFunction();
    DemoDistBetaNcQuantileFunction();
    DemoDistBetaNcInverseSurvivalFunction();
    DemoDistBetaNcMode();
    DemoDistBetaNcMedian();
    DemoDistBetaNcMean();
    DemoDistBetaNcVariance();
    DemoDistBetaNcStDev();
    DemoDistBetaNcSkewness();
    DemoDistBetaNcKurtosis();
    DemoDistBetaNcKurtosisExcess();
    DemoDistBetaNcSupportLowerEndpoint();
    DemoDistBetaNcSupportUpperEndpoint();
    DemoDistBetaNcRangeLowerEndpoint();
    DemoDistBetaNcRangeUpperEndpoint();
}


#region Demo DistBetaNc


#region Pdf
public static void DemoDistBetaNcPdf()
{
    Console.WriteLine("Demo BetaNc Distribution: Pdf");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_beta_nc(a, b, lambda1).pdf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Double Res00 = math53.beta_nc_pdf(a, b, lambda1, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).pdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).pdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).pdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).pdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).pdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).pdf(x);
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
public static void DemoDistBetaNcCdf()
{
    Console.WriteLine("Demo BetaNc Distribution: Cdf");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_beta_nc(a, b, lambda1).cdf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Double Res00 = math53.beta_nc_cdf(a, b, lambda1, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).cdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).cdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).cdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).cdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).cdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).cdf(x);
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
public static void DemoDistBetaNcSurvivalFunction()
{
    Console.WriteLine("Demo BetaNc Distribution: Survival Function");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_beta_nc(a, b, lambda1).sf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).sf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).sf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).sf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).sf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).sf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).sf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }}} // b, a
}
#endregion

#region Hazard Function

public static void DemoDistBetaNcHazardFunction()
{
    Console.WriteLine("Demo BetaNc Distribution: Hazard Function");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_beta_nc(a, b, lambda1).hf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).hf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).hf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).hf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).hf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).hf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).hf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }}} // b, a
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistBetaNcCumulativeHazardFunction()
{
    Console.WriteLine("Demo BetaNc Distribution: Cumulative Hazard Function");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_beta_nc(a, b, lambda1).chf(x); " 
        + "a={0}, b={1}, x={2}" + "\"" + ">", a, b, x);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).chf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).chf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).chf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).chf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).chf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).chf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }}} // b, a
}
#endregion

#region Quantile Function
public static void DemoDistBetaNcQuantileFunction()
{
    Console.WriteLine("Demo BetaNc Distribution: Quantile Function");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_beta_nc(a, b, lambda1).qtf(q); " + 
        "a={0}, b={1}, q={2}" + "\"" + ">", a, b, q);

    Double Res00 = math53.beta_nc_qtf(a, b, lambda1, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).qtf(q);
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
public static void DemoDistBetaNcInverseSurvivalFunction()
{
    Console.WriteLine("Demo BetaNc Distribution: Inverse Quantile Function");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_beta_nc(a, b, lambda1).isf(q); " + 
        "a={0}, b={1}, q={2}" + "\"" + ">", a, b, q);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).isf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    }}} // b, a
}
#endregion

#region Mode
public static void DemoDistBetaNcMode()
{
    Console.WriteLine("Demo BetaNc Distribution: Mode");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).mode();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Median
public static void DemoDistBetaNcMedian()
{
    Console.WriteLine("Demo BetaNc Distribution: Median");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).median();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Mean
public static void DemoDistBetaNcMean()
{
    Console.WriteLine("Demo BetaNc Distribution: Mean");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).mean();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Variance
public static void DemoDistBetaNcVariance()
{
    Console.WriteLine("Demo BetaNc Distribution: Variance");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).variance();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region StDev
public static void DemoDistBetaNcStDev()
{
    Console.WriteLine("Demo BetaNc Distribution: Standard Deviation");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).stdev();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Skewness
public static void DemoDistBetaNcSkewness()
{
    Console.WriteLine("Demo BetaNc Distribution: Skewness");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);

    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).skewness();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region Kurtosis
public static void DemoDistBetaNcKurtosis()
{
    Console.WriteLine("Demo BetaNc Distribution: Kurtosis");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);
    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).kurtosis();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region KurtosisExcess
public static void DemoDistBetaNcKurtosisExcess()
{
    Console.WriteLine("Demo BetaNc Distribution: Kurtosis Excess");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);
    Single Res01 = sreal.dist_beta_nc(a, b, lambda1).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_beta_nc(a, b, lambda1).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_beta_nc(a, b, lambda1).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_beta_nc(a, b, lambda1).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_beta_nc(a, b, lambda1).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).kurtosis_excess();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistBetaNcSupportLowerEndpoint()
{
    Console.WriteLine("Demo BetaNc Distribution: SupportLowerEndpoint");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1).support_lower_endpoint(); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);
    Single Res01L = sreal.dist_beta_nc(a, b, lambda1).support_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_beta_nc(a, b, lambda1).support_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_beta_nc(a, b, lambda1).support_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_beta_nc(a, b, lambda1).support_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_beta_nc(a, b, lambda1).support_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).support_lower_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine("</H1>");
    }}}
}
#endregion

#region SupportUpperEndpoint
public static void DemoDistBetaNcSupportUpperEndpoint()
{
    Console.WriteLine("Demo BetaNc Distribution: SupportUpperEndpoint");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1).support_upper_endpoint(); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);
    Single Res01R = sreal.dist_beta_nc(a, b, lambda1).support_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_beta_nc(a, b, lambda1).support_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_beta_nc(a, b, lambda1).support_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_beta_nc(a, b, lambda1).support_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_beta_nc(a, b, lambda1).support_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).support_upper_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    }}}
}
#endregion




#region RangeLowerEndpoint
public static void DemoDistBetaNcRangeLowerEndpoint()
{
    Console.WriteLine("Demo BetaNc Distribution: RangeLowerEndpoint");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1).range_lower_endpoint(); a={0}, b={1}, lambda1={2}" 
        + "\"" + ">", a, b, lambda1);
    Single Res01L = sreal.dist_beta_nc(a, b, lambda1).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_beta_nc(a, b, lambda1).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_beta_nc(a, b, lambda1).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_beta_nc(a, b, lambda1).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_beta_nc(a, b, lambda1).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).range_lower_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine("</H1>");
    }}}
}
#endregion


#region RangeUpperEndpoint
public static void DemoDistBetaNcRangeUpperEndpoint()
{
    Console.WriteLine("Demo BetaNc Distribution: RangeUpperEndpoint");
    foreach (var a in new[] { 1.5, 2.5, 3.5 }) {
    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    foreach (var lambda1 in new[] { 5.1 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_beta_nc(a, b, lambda1).range_upper_endpoint(); a={0}, b={1}, lambda1={2}"
        + "\"" + ">", a, b, lambda1);
    Single Res01R = sreal.dist_beta_nc(a, b, lambda1).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_beta_nc(a, b, lambda1).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_beta_nc(a, b, lambda1).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_beta_nc(a, b, lambda1).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_beta_nc(a, b, lambda1).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_beta_nc(a, b, lambda1).range_upper_endpoint();
    Console.WriteLine(" mreal: {0}", Res06);
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

