
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
    DemoDistStudentTPdf();
    DemoDistStudentTCdf();
    DemoDistStudentTSurvivalFunction();
    DemoDistStudentTHazardFunction();
    DemoDistStudentTCumulativeHazardFunction();
    DemoDistStudentTQuantileFunction();
    DemoDistStudentTInverseSurvivalFunction();
    DemoDistStudentTMode();
    DemoDistStudentTMedian();
    DemoDistStudentTMean();
    DemoDistStudentTVariance();
    DemoDistStudentTStDev();
    DemoDistStudentTSkewness();
    DemoDistStudentTKurtosis();
    DemoDistStudentTKurtosisExcess();
    DemoDistStudentTSupportLowerEndpoint();
    DemoDistStudentTSupportUpperEndpoint();
    DemoDistStudentTRangeLowerEndpoint();
    DemoDistStudentTRangeUpperEndpoint();
}


#region Demo DistStudentT


#region Pdf
public static void DemoDistStudentTPdf()
{
    Console.WriteLine("Demo StudentT Distribution: Pdf");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t(nu).pdf(x); " 
        + "nu={0}, x={1}" + "\"" + ">", nu, x);

    Double Res00 = math53.student_t_pdf((int)nu, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_student_t(nu).pdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).pdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).pdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).pdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).pdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).pdf(x);
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
public static void DemoDistStudentTCdf()
{
    Console.WriteLine("Demo StudentT Distribution: Cdf");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t(nu).cdf(x); " 
        + "nu={0}, x={1}" + "\"" + ">", nu, x);

    Double Res00 = math53.student_t_cdf((int)nu, x);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_student_t(nu).cdf(x);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).cdf(x);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).cdf(x);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).cdf(x);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).cdf(x);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).cdf(x);
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
public static void DemoDistStudentTSurvivalFunction()
{
    Console.WriteLine("Demo StudentT Distribution: Survival Function");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t(nu).sf(x); " 
        + "nu={0}, x={1}" + "\"" + ">", nu, x);

    Single Res01 = sreal.dist_student_t(nu).sf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).sf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).sf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).sf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).sf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).sf(x);
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

public static void DemoDistStudentTHazardFunction()
{
    Console.WriteLine("Demo StudentT Distribution: Hazard Function");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t(nu).hf(x); " 
        + "nu={0}, x={1}" + "\"" + ">", nu, x);

    Single Res01 = sreal.dist_student_t(nu).hf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).hf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).hf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).hf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).hf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).hf(x);
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
public static void DemoDistStudentTCumulativeHazardFunction()
{
    Console.WriteLine("Demo StudentT Distribution: Cumulative Hazard Function");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var x in new[] { 0.0, 0.333, 0.75, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t(nu).chf(x); " 
        + "nu={0}, x={1}" + "\"" + ">", nu, x);

    Single Res01 = sreal.dist_student_t(nu).chf(x);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).chf(x);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).chf(x);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).chf(x);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).chf(x);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).chf(x);
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
public static void DemoDistStudentTQuantileFunction()
{
    Console.WriteLine("Demo StudentT Distribution: Quantile Function");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t(nu).qtf(x); " 
        + "nu={0}, q={1}" + "\"" + ">", nu, q);

    Double Res00 = math53.student_t_qtf((int)nu, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_student_t(nu).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).qtf(q);
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
public static void DemoDistStudentTInverseSurvivalFunction()
{
    Console.WriteLine("Demo StudentT Distribution: Inverse Quantile Function");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_student_t(nu).isf(x); " 
        + "nu={0}, q={1}" + "\"" + ">", nu, q);

    Single Res01 = sreal.dist_student_t(nu).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).isf(q);
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
public static void DemoDistStudentTMode()
{
    Console.WriteLine("Demo StudentT Distribution: Mode");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_student_t(nu).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).mode();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } // nu
}
#endregion

#region Median
public static void DemoDistStudentTMedian()
{
    Console.WriteLine("Demo StudentT Distribution: Median");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_student_t(nu).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).median();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Mean
public static void DemoDistStudentTMean()
{
    Console.WriteLine("Demo StudentT Distribution: Mean");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_student_t(nu).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).mean();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Variance
public static void DemoDistStudentTVariance()
{
    Console.WriteLine("Demo StudentT Distribution: Variance");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_student_t(nu).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).variance();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region StDev
public static void DemoDistStudentTStDev()
{
    Console.WriteLine("Demo StudentT Distribution: Standard Deviation");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_student_t(nu).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).stdev();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Skewness
public static void DemoDistStudentTSkewness()
{
    Console.WriteLine("Demo StudentT Distribution: Skewness");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);

    Single Res01 = sreal.dist_student_t(nu).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).skewness();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Kurtosis
public static void DemoDistStudentTKurtosis()
{
    Console.WriteLine("Demo StudentT Distribution: Kurtosis");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);
    Single Res01 = sreal.dist_student_t(nu).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).kurtosis();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region KurtosisExcess
public static void DemoDistStudentTKurtosisExcess()
{
    Console.WriteLine("Demo StudentT Distribution: Kurtosis Excess");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu); nu={0}" 
        + "\"" + ">", nu);
    Single Res01 = sreal.dist_student_t(nu).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_student_t(nu).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_student_t(nu).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_student_t(nu).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_student_t(nu).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_student_t(nu).kurtosis_excess();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistStudentTSupportLowerEndpoint()
{
    Console.WriteLine("Demo StudentT Distribution: Support");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu).support_lower_endpoint(); nu={0}" 
        + "\"" + ">", nu);
    Single Res01L = sreal.dist_student_t(nu).support_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_student_t(nu).support_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_student_t(nu).support_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_student_t(nu).support_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_student_t(nu).support_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_student_t(nu).support_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region SupportUpperEndpoint
public static void DemoDistStudentTSupportUpperEndpoint()
{
    Console.WriteLine("Demo StudentT Distribution: Support Lower Endpoint");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu).support_upper_endpoint(); nu={0}" 
        + "\"" + ">", nu);
    Single Res01R = sreal.dist_student_t(nu).support_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_student_t(nu).support_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_student_t(nu).support_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_student_t(nu).support_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_student_t(nu).support_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_student_t(nu).support_upper_endpoint();
    Console.WriteLine("mreal: {0}", Res06R);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistStudentTRangeLowerEndpoint()
{   Console.WriteLine("Demo StudentT Distribution: Range UpperEndpoint");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu).range_lower_endpoint(); nu={0}" 
        + "\"" + ">", nu);
    Single Res01L = sreal.dist_student_t(nu).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_student_t(nu).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_student_t(nu).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_student_t(nu).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_student_t(nu).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_student_t(nu).range_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region RangeUpperEndpoint
public static void DemoDistStudentTRangeUpperEndpoint()
{
    Console.WriteLine("Demo StudentT Distribution: Range UpperEndpoint");
    foreach (var nu in new[] { 15.0, 25.0, 35.0 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_student_t(nu).range_upper_endpoint(); nu={0}" 
        + "\"" + ">", nu);
    Single Res01R = sreal.dist_student_t(nu).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_student_t(nu).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_student_t(nu).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_student_t(nu).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_student_t(nu).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_student_t(nu).range_upper_endpoint();
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

