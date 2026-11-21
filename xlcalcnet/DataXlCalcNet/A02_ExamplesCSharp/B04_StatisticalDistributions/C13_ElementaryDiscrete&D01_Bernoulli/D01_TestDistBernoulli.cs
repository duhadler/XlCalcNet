
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
    DemoDistBernoulliPmf();
    DemoDistBernoulliCdf();
    DemoDistBernoulliSurvivalFunction();
    DemoDistBernoulliHazardFunction();
    DemoDistBernoulliCumulativeHazardFunction();
    DemoDistBernoulliQuantileFunction();
    DemoDistBernoulliInverseSurvivalFunction();
    DemoDistBernoulliMode();
    DemoDistBernoulliMedian();
    DemoDistBernoulliMean();
    DemoDistBernoulliVariance();
    DemoDistBernoulliStDev();
    DemoDistBernoulliSkewness();
    DemoDistBernoulliKurtosis();
    DemoDistBernoulliKurtosisExcess();
    DemoDistBernoulliSupportLowerEndpoint();
    DemoDistBernoulliSupportUpperEndpoint();
    DemoDistBernoulliRangeLowerEndpoint();
    DemoDistBernoulliRangeUpperEndpoint();
}


#region Demo DistBernoulli


#region Pmf
public static void DemoDistBernoulliPmf()
{
    Console.WriteLine("Demo Bernoulli Distribution: Pmf");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    foreach (var k in new[] { 0.0, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_bernoulli(p).pmf(k); " 
        + "p={0}, k={1}" + "\"" + ">", p, k);

    Double Res00 = math53.bernoulli_pmf(p, (int)k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_bernoulli(p).pmf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).pmf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).pmf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).pmf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).pmf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).pmf(k);
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
public static void DemoDistBernoulliCdf()
{
    Console.WriteLine("Demo Bernoulli Distribution: Cdf");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    foreach (var k in new[] { 0.0, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_bernoulli(p).cdf(k); " 
        + "p={0}, k={1}" + "\"" + ">", p, k);

    Double Res00 = math53.bernoulli_cdf(p, (int)k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_bernoulli(p).cdf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).cdf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).cdf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).cdf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).cdf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).cdf(k);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Survival Function
public static void DemoDistBernoulliSurvivalFunction()
{
    Console.WriteLine("Demo Bernoulli Distribution: Survival Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    foreach (var k in new[] { 0.0, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_bernoulli(p).sf(k); " 
        + "p={0}, k={1}" + "\"" + ">", p, k);

    Single Res01 = sreal.dist_bernoulli(p).sf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).sf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).sf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).sf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).sf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).sf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Hazard Function

public static void DemoDistBernoulliHazardFunction()
{
    Console.WriteLine("Demo Bernoulli Distribution: Hazard Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    foreach (var k in new[] { 0.0, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_bernoulli(p).hf(k); " 
        + "p={0}, k={1}" + "\"" + ">", p, k);

    Single Res01 = sreal.dist_bernoulli(p).hf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).hf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).hf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).hf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).hf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).hf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistBernoulliCumulativeHazardFunction()
{
    Console.WriteLine("Demo Bernoulli Distribution: Cumulative Hazard Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    foreach (var k in new[] { 0.0, 1.0 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_bernoulli(p).chf(k); " 
        + "p={0}, k={1}" + "\"" + ">", p, k);

    Single Res01 = sreal.dist_bernoulli(p).chf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).chf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).chf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).chf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).chf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).chf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Quantile Function
public static void DemoDistBernoulliQuantileFunction()
{
    Console.WriteLine("Demo Bernoulli Distribution: Quantile Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_bernoulli(p).qtf(k); " 
        + "p={0}, q={1}" + "\"" + ">", p, q);

    Double Res00 = math53.bernoulli_qtf(p, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_bernoulli(p).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Inverse Survival Function
public static void DemoDistBernoulliInverseSurvivalFunction()
{
    Console.WriteLine("Demo Bernoulli Distribution: Inverse Quantile Function");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_bernoulli(p).isf(k); " 
        + "p={0}, q={1}" + "\"" + ">", p, q);

    Single Res01 = sreal.dist_bernoulli(p).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).isf(q);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Mode
public static void DemoDistBernoulliMode()
{
    Console.WriteLine("Demo Bernoulli Distribution: Mode");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_bernoulli(p).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).mode();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } // p
}
#endregion

#region Median
public static void DemoDistBernoulliMedian()
{
    Console.WriteLine("Demo Bernoulli Distribution: Median");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_bernoulli(p).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).median();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Mean
public static void DemoDistBernoulliMean()
{
    Console.WriteLine("Demo Bernoulli Distribution: Mean");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_bernoulli(p).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).mean();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Variance
public static void DemoDistBernoulliVariance()
{
    Console.WriteLine("Demo Bernoulli Distribution: Variance");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_bernoulli(p).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).variance();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region StDev
public static void DemoDistBernoulliStDev()
{
    Console.WriteLine("Demo Bernoulli Distribution: Standard Deviation");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_bernoulli(p).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).stdev();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Skewness
public static void DemoDistBernoulliSkewness()
{
    Console.WriteLine("Demo Bernoulli Distribution: Skewness");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);

    Single Res01 = sreal.dist_bernoulli(p).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).skewness();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Kurtosis
public static void DemoDistBernoulliKurtosis()
{
    Console.WriteLine("Demo Bernoulli Distribution: Kurtosis");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);
    Single Res01 = sreal.dist_bernoulli(p).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).kurtosis();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region KurtosisExcess
public static void DemoDistBernoulliKurtosisExcess()
{
    Console.WriteLine("Demo Bernoulli Distribution: Kurtosis Excess");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p); p={0}" 
        + "\"" + ">", p);
    Single Res01 = sreal.dist_bernoulli(p).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_bernoulli(p).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_bernoulli(p).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_bernoulli(p).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_bernoulli(p).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_bernoulli(p).kurtosis_excess();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistBernoulliSupportLowerEndpoint()
{
    Console.WriteLine("Demo Bernoulli Distribution: Support");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p).support_lower_endpoint(); p={0}" 
        + "\"" + ">", p);
    Single Res01L = sreal.dist_bernoulli(p).support_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_bernoulli(p).support_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_bernoulli(p).support_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_bernoulli(p).support_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_bernoulli(p).support_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_bernoulli(p).support_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region SupportUpperEndpoint
public static void DemoDistBernoulliSupportUpperEndpoint()
{
    Console.WriteLine("Demo Bernoulli Distribution: Support Lower Endpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p).support_upper_endpoint(); p={0}" 
        + "\"" + ">", p);
    Single Res01R = sreal.dist_bernoulli(p).support_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_bernoulli(p).support_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_bernoulli(p).support_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_bernoulli(p).support_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_bernoulli(p).support_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_bernoulli(p).support_upper_endpoint();
    Console.WriteLine("mreal: {0}", Res06R);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistBernoulliRangeLowerEndpoint()
{   Console.WriteLine("Demo Bernoulli Distribution: Range UpperEndpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p).range_lower_endpoint(); p={0}" 
        + "\"" + ">", p);
    Single Res01L = sreal.dist_bernoulli(p).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_bernoulli(p).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_bernoulli(p).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_bernoulli(p).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_bernoulli(p).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_bernoulli(p).range_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region RangeUpperEndpoint
public static void DemoDistBernoulliRangeUpperEndpoint()
{
    Console.WriteLine("Demo Bernoulli Distribution: Range UpperEndpoint");
    foreach (var p in new[] {0.0001, 0.333, 0.75, 0.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_bernoulli(p).range_upper_endpoint(); p={0}" 
        + "\"" + ">", p);
    Single Res01R = sreal.dist_bernoulli(p).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_bernoulli(p).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_bernoulli(p).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_bernoulli(p).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_bernoulli(p).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_bernoulli(p).range_upper_endpoint();
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

