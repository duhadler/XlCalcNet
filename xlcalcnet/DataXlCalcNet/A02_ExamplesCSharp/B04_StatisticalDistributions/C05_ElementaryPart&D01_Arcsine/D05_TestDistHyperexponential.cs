
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
    DemoDistHyperexponentialPdf();
    DemoDistHyperexponentialCdf();
    DemoDistHyperexponentialSurvivalFunction();
    DemoDistHyperexponentialHazardFunction();
    DemoDistHyperexponentialCumulativeHazardFunction();
    DemoDistHyperexponentialQuantileFunction();
    DemoDistHyperexponentialInverseSurvivalFunction();
    DemoDistHyperexponentialMode();
    DemoDistHyperexponentialMedian();
    DemoDistHyperexponentialMean();
    DemoDistHyperexponentialVariance();
    DemoDistHyperexponentialStDev();
    DemoDistHyperexponentialSkewness();
    DemoDistHyperexponentialKurtosis();
    DemoDistHyperexponentialKurtosisExcess();
    DemoDistHyperexponentialSupportLowerEndpoint();
    DemoDistHyperexponentialSupportUpperEndpoint();
    DemoDistHyperexponentialRangeLowerEndpoint();
    DemoDistHyperexponentialRangeUpperEndpoint();
}


#region Demo DistHyperexponential


#region Pdf
public static void DemoDistHyperexponentialPdf()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Pdf");
//    foreach (var a in new[] { -1.5, -2.5, -3.5 }) {
//    foreach (var b in new[] { 5.1, 12.1, 53.5 }) {
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;


    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hyperexponential(a, b).pdf(x); x={0} " 
        + "\"" + ">", x);

    Double Res00 = math53.hyperexponential_pdf(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3), x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).pdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).pdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).pdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).pdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).pdf(x);
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).pdf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
//    }}
}
#endregion

#region Cdf
public static void DemoDistHyperexponentialCdf()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Cdf");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");
    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hyperexponential(a, b).cdf(x); x={0} " 
        + "\"" + ">", x);

    Double Res00 = math53.hyperexponential_cdf(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3), x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).cdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).cdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).cdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).cdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).cdf(x);
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).cdf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
}
#endregion

#region Survival Function
public static void DemoDistHyperexponentialSurvivalFunction()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Sf");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");
    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hyperexponential(a, b).sdf(x); x={0} " 
        + "\"" + ">", x);

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).sf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).sf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).sf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).sf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).sf(x);
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).sf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
}
#endregion

#region Hazard Function

public static void DemoDistHyperexponentialHazardFunction()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Hazard Function");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");
    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hyperexponential(a, b).hf(x); x={0} " 
        + "\"" + ">", x);

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).hf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).hf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).hf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).hf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).hf(x);
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).hf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistHyperexponentialCumulativeHazardFunction()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Cumulative Hazard Function");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");
    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hyperexponential(a, b).chf(x); x={0} " 
        + "\"" + ">", x);

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).chf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).chf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).chf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).chf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).chf(x);
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).chf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
}
#endregion

#region Quantile Function
public static void DemoDistHyperexponentialQuantileFunction()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Quantile Function");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");
    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hyperexponential(a, b).qtf(q); " + 
        "q={0}" + "\"" + ">", q);

    Double Res00 = math53.hyperexponential_qtf(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3), q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
}
#endregion

#region Inverse Survival Function
public static void DemoDistHyperexponentialInverseSurvivalFunction()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Inverse Survival Function");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");
    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_hyperexponential(a, b).qtf(q); " + 
        "q={0}" + "\"" + ">", q);

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).isf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).isf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).isf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).isf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).isf(q);
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).isf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    }
    Console.WriteLine("</H1>");
}
#endregion

#region Mode
public static void DemoDistHyperexponentialMode()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Mode");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).mode();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).mode();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).mode();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).mode();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).mode();
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).mode();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
}
#endregion

#region Median
public static void DemoDistHyperexponentialMedian()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Median");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).median();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).median();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).median();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).median();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).median();
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).median();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
}

#endregion

#region Mean
public static void DemoDistHyperexponentialMean()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Mean");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).mean();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).mean();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).mean();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).mean();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).mean();
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).mean();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
}
#endregion

#region Variance
public static void DemoDistHyperexponentialVariance()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Variance");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).variance();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).variance();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).variance();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).variance();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).variance();
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).variance();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
}
#endregion

#region StDev
public static void DemoDistHyperexponentialStDev()
{
    Console.WriteLine("Demo Hyperexponential Distribution: StDev");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).stdev();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).stdev();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).stdev();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).stdev();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).stdev();
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).stdev();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
}
#endregion

#region Skewness
public static void DemoDistHyperexponentialSkewness()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Skewness");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).skewness();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).skewness();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).skewness();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).skewness();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).skewness();
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).skewness();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
}
#endregion

#region Kurtosis
public static void DemoDistHyperexponentialKurtosis()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Kurtosis");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).kurtosis();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).kurtosis();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).kurtosis();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).kurtosis();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).kurtosis();
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).kurtosis();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
}
#endregion

#region KurtosisExcess
public static void DemoDistHyperexponentialKurtosisExcess()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Kurtosis Excess");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;
    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b)" 
        + "\"" + ">");

    Single Res01 = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).kurtosis_excess();
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).kurtosis_excess();
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).kurtosis_excess();
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).kurtosis_excess();
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).kurtosis_excess();
    Console.WriteLine(" oreal: {0}", Res05);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).kurtosis_excess();
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistHyperexponentialSupportLowerEndpoint()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Support Lower Endpoint");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;

    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b).support_lower_endpoint();" 
        + "" + "\"" + ">");
    Single Res01L = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).support_lower_endpoint();
    Console.WriteLine(" sreal: {0}", Res01L);
    Double Res02L = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).support_lower_endpoint();
    Console.WriteLine(" dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).support_lower_endpoint();
    Console.WriteLine(" ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).support_lower_endpoint();
    Console.WriteLine(" qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).support_lower_endpoint();
    Console.WriteLine(" oreal: {0}", Res05L);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).support_lower_endpoint();
    Console.WriteLine(" mreal: {0}", Res06L);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
}
#endregion

#region SupportUpperEndpoint
public static void DemoDistHyperexponentialSupportUpperEndpoint()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Support Upper Endpoint");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;

    Console.WriteLine("</H1>");

    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b).support_upper_endpoint()" 
        + ";" + "\"" + ">");
    Single Res01R = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).support_upper_endpoint();
    Console.WriteLine(" sreal: {0}", Res01R);
    Double Res02R = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).support_upper_endpoint();
    Console.WriteLine(" dreal: {0}", Res02R);
    Extended Res03R = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).support_upper_endpoint();
    Console.WriteLine(" ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).support_upper_endpoint();
    Console.WriteLine(" qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).support_upper_endpoint();
    Console.WriteLine(" oreal: {0}", Res05R);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).support_upper_endpoint();
    Console.WriteLine(" mreal: {0}", Res06R);
#endif
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistHyperexponentialRangeLowerEndpoint()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Range Lower Endpoint");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;

    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b).range_lower_endpoint();"
        + "" + "\"" + ">");
    Single Res01L = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).range_lower_endpoint();
    Console.WriteLine(" sreal: {0}", Res01L);
    Double Res02L = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).range_lower_endpoint();
    Console.WriteLine(" dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).range_lower_endpoint();
    Console.WriteLine(" ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).range_lower_endpoint();
    Console.WriteLine(" qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).range_lower_endpoint();
    Console.WriteLine(" oreal: {0}", Res05L);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).range_lower_endpoint();
    Console.WriteLine(" mreal: {0}", Res06L);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
}
#endregion

#region RangeUpperEndpoint
public static void DemoDistHyperexponentialRangeUpperEndpoint()
{
    Console.WriteLine("Demo Hyperexponential Distribution: Range Upper Endpoint");
    double a1 = 0.2; double l1 = 0.5;
    double a2 = 0.3; double l2 = 1.0;
    double a3 = 0.5; double l3 = 1.5;

    Console.WriteLine("<H1 Title=" + "\"" + "dist_hyperexponential(a, b).range_upper_endpoint();"
        + "" + "\"" + ">");
    Single Res01R = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), 
        sreal.VecParams(l1, l2, l3)).range_upper_endpoint();
    Console.WriteLine(" sreal: {0}", Res01R);
    Double Res02R = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), 
        dreal.VecParams(l1, l2, l3)).range_upper_endpoint();
    Console.WriteLine(" dreal: {0}", Res02R);
    Extended Res03R = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), 
        ereal.VecParams(l1, l2, l3)).range_upper_endpoint();
    Console.WriteLine(" ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), 
        qreal.VecParams(l1, l2, l3)).range_upper_endpoint();
    Console.WriteLine(" qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), 
        oreal.VecParams(l1, l2, l3)).range_upper_endpoint();
    Console.WriteLine(" oreal: {0}", Res05R);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), 
        mreal.VecParams(l1, l2, l3)).range_upper_endpoint();
    Console.WriteLine(" mreal: {0}", Res06R);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
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

