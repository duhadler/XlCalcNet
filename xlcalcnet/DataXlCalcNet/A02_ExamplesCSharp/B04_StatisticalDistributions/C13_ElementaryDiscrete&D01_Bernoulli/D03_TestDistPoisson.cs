
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
    DemoDistPoissonPmf();
    DemoDistPoissonCdf();
    DemoDistPoissonSurvivalFunction();
    DemoDistPoissonHazardFunction();
    DemoDistPoissonCumulativeHazardFunction();
    DemoDistPoissonQuantileFunction();
    DemoDistPoissonInverseSurvivalFunction();
    DemoDistPoissonMode();
    DemoDistPoissonMedian();
    DemoDistPoissonMean();
    DemoDistPoissonVariance();
    DemoDistPoissonStDev();
    DemoDistPoissonSkewness();
    DemoDistPoissonKurtosis();
    DemoDistPoissonKurtosisExcess();
    DemoDistPoissonSupportLowerEndpoint();
    DemoDistPoissonSupportUpperEndpoint();
    DemoDistPoissonRangeLowerEndpoint();
    DemoDistPoissonRangeUpperEndpoint();
}


#region Demo DistPoisson


#region Pmf
public static void DemoDistPoissonPmf()
{
    Console.WriteLine("Demo Poisson Distribution: Pmf");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    foreach (var k in new[] { 0, 33, 75, 100 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_poisson(mu).pmf(k); " 
        + "mu={0}, k={1}" + "\"" + ">", mu, k);

    Double Res00 = math53.poisson_pmf(mu, (int)k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_poisson(mu).pmf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).pmf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).pmf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).pmf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).pmf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).pmf(k);
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
public static void DemoDistPoissonCdf()
{
    Console.WriteLine("Demo Poisson Distribution: Cdf");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    foreach (var k in new[] { 0, 33, 75, 100 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_poisson(mu).cdf(k); " 
        + "mu={0}, k={1}" + "\"" + ">", mu, k);

    Double Res00 = math53.poisson_cdf(mu, (int)k);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_poisson(mu).cdf(k);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).cdf(k);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).cdf(k);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).cdf(k);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).cdf(k);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).cdf(k);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // mu
}
#endregion

#region Survival Function
public static void DemoDistPoissonSurvivalFunction()
{
    Console.WriteLine("Demo Poisson Distribution: Survival Function");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    foreach (var k in new[] { 0, 33, 75, 100 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_poisson(mu).sf(k); " 
        + "mu={0}, k={1}" + "\"" + ">", mu, k);

    Single Res01 = sreal.dist_poisson(mu).sf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).sf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).sf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).sf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).sf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).sf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // mu
}
#endregion

#region Hazard Function

public static void DemoDistPoissonHazardFunction()
{
    Console.WriteLine("Demo Poisson Distribution: Hazard Function");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    foreach (var k in new[] { 0, 33, 75, 100 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_poisson(mu).hf(k); " 
        + "mu={0}, k={1}" + "\"" + ">", mu, k);

    Single Res01 = sreal.dist_poisson(mu).hf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).hf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).hf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).hf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).hf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).hf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // mu
}

#endregion

#region Cumulative Hazard Function
public static void DemoDistPoissonCumulativeHazardFunction()
{
    Console.WriteLine("Demo Poisson Distribution: Cumulative Hazard Function");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    foreach (var k in new[] { 0, 33, 75, 100 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_poisson(mu).chf(k); " 
        + "mu={0}, k={1}" + "\"" + ">", mu, k);

    Single Res01 = sreal.dist_poisson(mu).chf(k);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).chf(k);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).chf(k);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).chf(k);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).chf(k);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).chf(k);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // mu
}
#endregion

#region Quantile Function
public static void DemoDistPoissonQuantileFunction()
{
    Console.WriteLine("Demo Poisson Distribution: Quantile Function");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_poisson(mu).qtf(k); " 
        + "mu={0}, q={1}" + "\"" + ">", mu, q);

    Double Res00 = math53.poisson_qtf(mu, q);
    Console.WriteLine("math53: {0}", Res00);

    Single Res01 = sreal.dist_poisson(mu).qtf(q);
    Console.WriteLine(" sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).qtf(q);
    Console.WriteLine(" dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).qtf(q);
    Console.WriteLine(" ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).qtf(q);
    Console.WriteLine(" qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).qtf(q);
    Console.WriteLine(" oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).qtf(q);
    Console.WriteLine(" mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // mu
}
#endregion

#region Inverse Survival Function
public static void DemoDistPoissonInverseSurvivalFunction()
{
    Console.WriteLine("Demo Poisson Distribution: Inverse Quantile Function");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    foreach (var q in new[] { 0.0001, 0.333, 0.75, 0.999 }) {
    Console.WriteLine("<H2 Title=" + "\"" + "dist_poisson(mu).isf(k); " 
        + "mu={0}, q={1}" + "\"" + ">", mu, q);

    Single Res01 = sreal.dist_poisson(mu).isf(q);
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).isf(q);
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).isf(q);
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).isf(q);
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).isf(q);
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).isf(q);
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H2>");
    } // k
    Console.WriteLine("</H1>");
    } // mu
}
#endregion

#region Mode
public static void DemoDistPoissonMode()
{
    Console.WriteLine("Demo Poisson Distribution: Mode");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    Single Res01 = sreal.dist_poisson(mu).mode();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).mode();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).mode();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).mode();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).mode();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).mode();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } // mu
}
#endregion

#region Median
public static void DemoDistPoissonMedian()
{
    Console.WriteLine("Demo Poisson Distribution: Median");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    Single Res01 = sreal.dist_poisson(mu).median();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).median();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).median();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).median();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).median();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).median();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Mean
public static void DemoDistPoissonMean()
{
    Console.WriteLine("Demo Poisson Distribution: Mean");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    Single Res01 = sreal.dist_poisson(mu).mean();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).mean();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).mean();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).mean();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).mean();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).mean();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Variance
public static void DemoDistPoissonVariance()
{
    Console.WriteLine("Demo Poisson Distribution: Variance");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    Single Res01 = sreal.dist_poisson(mu).variance();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).variance();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).variance();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).variance();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).variance();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).variance();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region StDev
public static void DemoDistPoissonStDev()
{
    Console.WriteLine("Demo Poisson Distribution: Standard Deviation");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    Single Res01 = sreal.dist_poisson(mu).stdev();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).stdev();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).stdev();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).stdev();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).stdev();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).stdev();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Skewness
public static void DemoDistPoissonSkewness()
{
    Console.WriteLine("Demo Poisson Distribution: Skewness");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);

    Single Res01 = sreal.dist_poisson(mu).skewness();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).skewness();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).skewness();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).skewness();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).skewness();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).skewness();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region Kurtosis
public static void DemoDistPoissonKurtosis()
{
    Console.WriteLine("Demo Poisson Distribution: Kurtosis");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);
    Single Res01 = sreal.dist_poisson(mu).kurtosis();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).kurtosis();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).kurtosis();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).kurtosis();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).kurtosis();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).kurtosis();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region KurtosisExcess
public static void DemoDistPoissonKurtosisExcess()
{
    Console.WriteLine("Demo Poisson Distribution: Kurtosis Excess");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {
    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu); mu={0}" 
        + "\"" + ">", mu);
    Single Res01 = sreal.dist_poisson(mu).kurtosis_excess();
    Console.WriteLine("sreal: {0}", Res01);
    Double Res02 = dreal.dist_poisson(mu).kurtosis_excess();
    Console.WriteLine("dreal: {0}", Res02);
    Extended Res03 = ereal.dist_poisson(mu).kurtosis_excess();
    Console.WriteLine("ereal: {0}", Res03);
    Quadruple Res04 = qreal.dist_poisson(mu).kurtosis_excess();
    Console.WriteLine("qreal: {0}", Res04);
    Octuple Res05 = oreal.dist_poisson(mu).kurtosis_excess();
    Console.WriteLine("oreal: {0}", Res05);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06 = mreal.dist_poisson(mu).kurtosis_excess();
    Console.WriteLine("mreal: {0}", Res06);
#endif

    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region SupportLowerEndpoint
public static void DemoDistPoissonSupportLowerEndpoint()
{
    Console.WriteLine("Demo Poisson Distribution: Support");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu).support_lower_endpoint(); mu={0}" 
        + "\"" + ">", mu);
    Single Res01L = sreal.dist_poisson(mu).support_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_poisson(mu).support_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_poisson(mu).support_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_poisson(mu).support_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_poisson(mu).support_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_poisson(mu).support_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region SupportUpperEndpoint
public static void DemoDistPoissonSupportUpperEndpoint()
{
    Console.WriteLine("Demo Poisson Distribution: Support Lower Endpoint");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu).support_upper_endpoint(); mu={0}" 
        + "\"" + ">", mu);
    Single Res01R = sreal.dist_poisson(mu).support_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_poisson(mu).support_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_poisson(mu).support_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_poisson(mu).support_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_poisson(mu).support_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_poisson(mu).support_upper_endpoint();
    Console.WriteLine("mreal: {0}", Res06R);
#endif
    Console.WriteLine();
    Console.WriteLine("</H1>");
    } 
}
#endregion

#region RangeLowerEndpoint
public static void DemoDistPoissonRangeLowerEndpoint()
{   Console.WriteLine("Demo Poisson Distribution: Range UpperEndpoint");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu).range_lower_endpoint(); mu={0}" 
        + "\"" + ">", mu);
    Single Res01L = sreal.dist_poisson(mu).range_lower_endpoint();
    Console.WriteLine("sreal: {0}", Res01L);
    Double Res02L = dreal.dist_poisson(mu).range_lower_endpoint();
    Console.WriteLine("dreal: {0}", Res02L);
    Extended Res03L = ereal.dist_poisson(mu).range_lower_endpoint();
    Console.WriteLine("ereal: {0}", Res03L);
    Quadruple Res04L = qreal.dist_poisson(mu).range_lower_endpoint();
    Console.WriteLine("qreal: {0}", Res04L);
    Octuple Res05L = oreal.dist_poisson(mu).range_lower_endpoint();
    Console.WriteLine("oreal: {0}", Res05L);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06L = mreal.dist_poisson(mu).range_lower_endpoint();
    Console.WriteLine("mreal: {0}", Res06L);
#endif
    Console.WriteLine("</H1>");
    } 
}
#endregion


#region RangeUpperEndpoint
public static void DemoDistPoissonRangeUpperEndpoint()
{
    Console.WriteLine("Demo Poisson Distribution: Range UpperEndpoint");
    foreach (var mu in new[] {1.0001, 10.333, 20.75, 30.999 }) {

    Console.WriteLine("<H1 Title=" + "\"" + "dist_poisson(mu).range_upper_endpoint(); mu={0}" 
        + "\"" + ">", mu);
    Single Res01R = sreal.dist_poisson(mu).range_upper_endpoint();
    Console.WriteLine("sreal: {0}", Res01R);
    Double Res02R = dreal.dist_poisson(mu).range_upper_endpoint();
    Console.WriteLine("dreal: {0}", Res02R);    
    Extended Res03R = ereal.dist_poisson(mu).range_upper_endpoint();
    Console.WriteLine("ereal: {0}", Res03R);
    Quadruple Res04R = qreal.dist_poisson(mu).range_upper_endpoint();
    Console.WriteLine("qreal: {0}", Res04R);
    Octuple Res05R = oreal.dist_poisson(mu).range_upper_endpoint();
    Console.WriteLine("oreal: {0}", Res05R);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    Mpfr Res06R = mreal.dist_poisson(mu).range_upper_endpoint();
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

