
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
    DemoDistChi2Pdf();
    DemoDistChi2Cdf();
    DemoDistChi2SurvivalFunction();
    DemoDistChi2HazardFunction();
    DemoDistChi2CumulativeHazardFunction();
    DemoDistChi2QuantileFunction();
    DemoDistChi2InverseSurvivalFunction();
    DemoDistChi2Mode();
    DemoDistChi2Median();
    DemoDistChi2Mean();
    DemoDistChi2Variance();
    DemoDistChi2StDev();
    DemoDistChi2Skewness();
    DemoDistChi2Kurtosis();
    DemoDistChi2KurtosisExcess();
    DemoDistChi2SupportLowerEndpoint();
    DemoDistChi2SupportUpperEndpoint();
    DemoDistChi2RangeLowerEndpoint();
    DemoDistChi2RangeUpperEndpoint();
}


#region Demo DistChi2


#region Pdf
public static void DemoDistChi2Pdf()
{
    Console.WriteLine("Demo Chi2 Distribution: Pdf");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2(nu).pdf(x); " 
        + "nu={0}, x={1}" + "\"" + ">", nu, x);

    Double Res00 = math53.chi2_pdf((int)nu, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_chi2(nu).pdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).pdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).pdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).pdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).pdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).pdf(x);
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
public static void DemoDistChi2Cdf()
{
    Console.WriteLine("Demo Chi2 Distribution: Cdf");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2(nu).cdf(x); " 
        + "nu={0}, x={1}" + "\"" + ">", nu, x);

    Double Res00 = math53.chi2_cdf((int)nu, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_chi2(nu).cdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).cdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).cdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).cdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).cdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).cdf(x);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // nu
}
#endregion

#region Survival Function
public static void DemoDistChi2SurvivalFunction()
{
    Console.WriteLine("Demo Chi2 Distribution: Survival Function");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2(nu).sf(x); " 
        + "nu={0}, x={1}" + "\"" + ">", nu, x);

    Single Res01 = sreal.dist_chi2(nu).sf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).sf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).sf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).sf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).sf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).sf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // nu
}
#endregion

#region Hazard Function

public static void DemoDistChi2HazardFunction()
{
    Console.WriteLine("Demo Chi2 Distribution: Hazard Function");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2(nu).hf(x); " 
        + "nu={0}, x={1}" + "\"" + ">", nu, x);

    Single Res01 = sreal.dist_chi2(nu).hf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).hf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).hf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).hf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).hf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).hf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // nu
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistChi2CumulativeHazardFunction()
{
    Console.WriteLine("Demo Chi2 Distribution: Cumulative Hazard Function");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2(nu).chf(x); " 
        + "nu={0}, x={1}" + "\"" + ">", nu, x);

    Single Res01 = sreal.dist_chi2(nu).chf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).chf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).chf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).chf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).chf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).chf(x);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // nu
}
#endregion

#region Quantile Function
public static void DemoDistChi2QuantileFunction()
{
    Console.WriteLine("Demo Chi2 Distribution: Quantile Function");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2(nu).qtf(x); " 
        + "nu={0}, q={1}" + "\"" + ">", nu, q);

    Double Res00 = math53.chi2_qtf((int)nu, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_chi2(nu).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // nu
}
#endregion

#region Inverse Survival Function
public static void DemoDistChi2InverseSurvivalFunction()
{
    Console.WriteLine("Demo Chi2 Distribution: Inverse Quantile Function");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_chi2(nu).isf(x); " 
        + "nu={0}, q={1}" + "\"" + ">", nu, q);

    Single Res01 = sreal.dist_chi2(nu).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).isf(q);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // x
    Console.WriteLine("</H1>");
    } // nu
}
#endregion

#region Mode
public static void DemoDistChi2Mode()
{
    Console.WriteLine("Demo Chi2 Distribution: Mode");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_chi2(nu).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).mode();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } // nu
}
#endregion

#region Median
public static void DemoDistChi2Median()
{
    Console.WriteLine("Demo Chi2 Distribution: Median");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_chi2(nu).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).median();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Mean
public static void DemoDistChi2Mean()
{
    Console.WriteLine("Demo Chi2 Distribution: Mean");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_chi2(nu).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).mean();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Variance
public static void DemoDistChi2Variance()
{
    Console.WriteLine("Demo Chi2 Distribution: Variance");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_chi2(nu).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).variance();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region StDev
public static void DemoDistChi2StDev()
{
    Console.WriteLine("Demo Chi2 Distribution: Standard Deviation");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_chi2(nu).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).stdev();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Skewness
public static void DemoDistChi2Skewness()
{
    Console.WriteLine("Demo Chi2 Distribution: Skewness");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_chi2(nu).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).skewness();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Kurtosis
public static void DemoDistChi2Kurtosis()
{
    Console.WriteLine("Demo Chi2 Distribution: Kurtosis");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);
    Single Res01 = sreal.dist_chi2(nu).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).kurtosis();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region KurtosisExcess
public static void DemoDistChi2KurtosisExcess()
{
    Console.WriteLine("Demo Chi2 Distribution: Kurtosis Excess");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu); nu={0}" 
        + "\"" + ">", nu);
    Single Res01 = sreal.dist_chi2(nu).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_chi2(nu).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_chi2(nu).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_chi2(nu).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_chi2(nu).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_chi2(nu).kurtosis_excess();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistChi2SupportLowerEndpoint()
{
    Console.WriteLine("Demo Chi2 Distribution: Support");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu).support_lower_endpoint(); nu={0}" 
        + "\"" + ">", nu);
    Single Res01L = sreal.dist_chi2(nu).support_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_chi2(nu).support_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_chi2(nu).support_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_chi2(nu).support_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_chi2(nu).support_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_chi2(nu).support_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region SupportUpperEndpoint
public static void DemoDistChi2SupportUpperEndpoint()
{
    Console.WriteLine("Demo Chi2 Distribution: Support Lower Endpoint");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu).support_upper_endpoint(); nu={0}" 
        + "\"" + ">", nu);
    Single Res01R = sreal.dist_chi2(nu).support_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_chi2(nu).support_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_chi2(nu).support_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_chi2(nu).support_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_chi2(nu).support_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_chi2(nu).support_upper_endpoint();
    Console.WriteLine("mreal: {0}", Res06R);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistChi2RangeLowerEndpoint()
{   Console.WriteLine("Demo Chi2 Distribution: Range UpperEndpoint");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu).range_lower_endpoint(); nu={0}" 
        + "\"" + ">", nu);
    Single Res01L = sreal.dist_chi2(nu).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_chi2(nu).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_chi2(nu).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_chi2(nu).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_chi2(nu).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_chi2(nu).range_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region RangeUpperEndpoint
public static void DemoDistChi2RangeUpperEndpoint()
{
    Console.WriteLine("Demo Chi2 Distribution: Range UpperEndpoint");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_chi2(nu).range_upper_endpoint(); nu={0}" 
        + "\"" + ">", nu);
    Single Res01R = sreal.dist_chi2(nu).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_chi2(nu).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_chi2(nu).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_chi2(nu).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_chi2(nu).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_chi2(nu).range_upper_endpoint();
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

