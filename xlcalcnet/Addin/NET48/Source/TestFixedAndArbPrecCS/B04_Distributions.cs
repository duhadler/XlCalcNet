
#region Usings

using System;
using System.Diagnostics;
using System.Linq;
using FixedPrecNet;


#if HasArbPrecNet
using ArbPrecNet;

using mDistClass = ArbPrecNet.mreal.BaseDistClass;
using mDistContClass = ArbPrecNet.mreal.BaseDistContClass;
using mDistDiscreteClass = ArbPrecNet.mreal.BaseDistDiscreteClass;
#else

using mDistClass = System.Object;
using mDistContClass = System.Object;
using mDistDiscreteClass = System.Object;
#endif

#endregion


namespace TestXlCalcNetPrecCS
{

    static partial class Tests
    {

        public static void RunTestsDistributions()
        {
# if HasArbPrecNet
            ArbPrec.SetDps(72);
#endif
            string[] NumTypeArray = new[] { " sreal", " dreal", " ereal", " qreal", " oreal", " mreal" };
            //string[] NumTypeArray = new[] { " sreal"};

            //string[] DistArray = new[] { "all", "dist_bernoulli", "dist_geometric", "dist_poisson", "dist_binomial", "dist_negbinomial", "dist_hypergeometric", "dist_logseries", "dist_zeta"  "dist_arcsine", "dist_cauchy", "dist_exponential", "dist_gumbel", "dist_hyperexponential", "dist_kumaraswamy", "dist_laplace", "dist_logistic", "dist_pareto", "dist_rayleigh", "dist_triangular", "dist_uniform", "dist_weibull", "dist_levy", "dist_lognormal", "dist_moyal", "dist_normal", "dist_skewnormal", "dist_wald", "dist_chi", "dist_chi2", "dist_gamma", "dist_inverse_chi2", "dist_inverse_gamma", "dist_maxwell", "dist_nakagami", "dist_beta", "dist_fisher_f", "dist_student_t", "dist_chi2_nc", "dist_Student_t_nc", "dist_fisher_f_nc", "dist_beta_nc", "dist_kolmogorov_smirnov", "dist_holtsmark",  "dist_landau", "dist_mapairy", "dist_saspoint5", };
            string[] DistArray = new[] { "dist_beta_nc" };
            //string[] DistArray = new[] { "dist_wald" };

            //string[] FunctionArray = new[] { "all" };
            //string[] FunctionArray = new[] { "pdf", "pmf", "cdf", "sf", "hf", "chf", "qtf", "isf", "mean", "median", "mode", "variance", "stdev", "skewness", "kurtosis", "kurtosis_excess", "support_lower_endpoint", "support_upper_endpoint", "range_lower_endpoint", "range_upper_endpoint"};

            string[] FunctionArray = new[] { "all" };

            ShowDist(NumTypeArray, DistArray, FunctionArray);
        }




        #region Boost Distributions

        public static void ShowDist(string[] NumTypeArray, string[] DistArray, string[] FunctionArray)
        {

            #region Local variables

            double[] XInputArray;
            double[] QInputArray;
            sreal.BaseDistContClass sDist;
            dreal.BaseDistContClass dDist;
            ereal.BaseDistContClass eDist;
            qreal.BaseDistContClass qDist;
            oreal.BaseDistContClass oDist;
            mDistContClass mDist;

            sreal.BaseDistDiscreteClass sDist1;
            dreal.BaseDistDiscreteClass dDist1;
            ereal.BaseDistDiscreteClass eDist1;
            qreal.BaseDistDiscreteClass qDist1;
            oreal.BaseDistDiscreteClass oDist1;
            mDistDiscreteClass mDist1;

#if HasArbPrecNet
            mDist = null;
#endif

            #endregion


            #region Discrete (lattice) distribution functions


            if (DistArray.Contains("all") | DistArray.Contains("dist_bernoulli"))
            {
                XInputArray = new[] { 0.0, 1.0 };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var p in new[] { 0.1d, 0.3d, 0.5d, 0.7d, 0.9d })
                {
                    sDist1 = sreal.dist_bernoulli(p);
                    dDist1 = dreal.dist_bernoulli(p);
                    eDist1 = ereal.dist_bernoulli(p);
                    qDist1 = qreal.dist_bernoulli(p);
                    oDist1 = oreal.dist_bernoulli(p);
#if HasArbPrecNet
                    mDist1 = mreal.dist_bernoulli(p);
#endif
                    string DStr = string.Format("dist_bernoulli(p={0})", p);
                    ShowDistLattice(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist1, dDist1, eDist1, qDist1, oDist1, mDist1);
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_geometric"))
            {
                XInputArray = new[] { 1.0d, 3.0d, 8.0d, 10.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var p in new[] { 0.1d, 0.3d, 0.5d })
                {
                    sDist1 = sreal.dist_geometric(p);
                    dDist1 = dreal.dist_geometric(p);
                    eDist1 = ereal.dist_geometric(p);
                    qDist1 = qreal.dist_geometric(p);
                    oDist1 = oreal.dist_geometric(p);
#if HasArbPrecNet
                    mDist1 = mreal.dist_geometric(p);
#endif
                    string DStr = string.Format("dist_geometric(p={0})", p);
                    ShowDistLattice(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist1, dDist1, eDist1, qDist1, oDist1, mDist1);
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_poisson"))
            {
                XInputArray = new[] { 1.0d, 3.0d, 8.0d, 10.0d };
                QInputArray = new[] { 0.0d, 0.00333d, 0.075d, 0.1d };
                foreach (var mu in new[] { 0.1d, 0.3d, 0.5d })
                {
                    sDist1 = sreal.dist_poisson(mu);
                    dDist1 = dreal.dist_poisson(mu);
                    eDist1 = ereal.dist_poisson(mu);
                    qDist1 = qreal.dist_poisson(mu);
                    oDist1 = oreal.dist_poisson(mu);
#if HasArbPrecNet
                    mDist1 = mreal.dist_poisson(mu);
#endif
                    string DStr = string.Format("dist_poisson(mu={0})", mu);
                    ShowDistLattice(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist1, dDist1, eDist1, qDist1, oDist1, mDist1);
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_binomial"))
            {
                XInputArray = new[] { 1.0d, 3.0d, 8.0d, 10.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var n in new[] { 15, 25, 35 })
                {
                    foreach (var p in new[] { 0.1d, 0.3d, 0.5d })
                    {
                        sDist1 = sreal.dist_binomial(n, p);
                        dDist1 = dreal.dist_binomial(n, p);
                        eDist1 = ereal.dist_binomial(n, p);
                        qDist1 = qreal.dist_binomial(n, p);
                        oDist1 = oreal.dist_binomial(n, p);
#if HasArbPrecNet
                        mDist1 = mreal.dist_binomial(n, p);
#endif
                        string DStr = string.Format("dist_binomial(n={0}, p={1})", n, p);
                        ShowDistLattice(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist1, dDist1, eDist1, qDist1, oDist1, mDist1);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_negbinomial"))
            {
                XInputArray = new[] { 1.0d, 3.0d, 8.0d, 10.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var r in new[] { 15, 25, 35 })
                {
                    foreach (var p in new[] { 0.1d, 0.3d, 0.5d })
                    {
                        sDist1 = sreal.dist_negbinomial(r, p);
                        dDist1 = dreal.dist_negbinomial(r, p);
                        eDist1 = ereal.dist_negbinomial(r, p);
                        qDist1 = qreal.dist_negbinomial(r, p);
                        oDist1 = oreal.dist_negbinomial(r, p);
#if HasArbPrecNet
                        mDist1 = mreal.dist_negbinomial(r, p);
#endif
                        string DStr = string.Format("dist_negbinomial(r={0}, p={1})", r, p);
                        ShowDistLattice(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist1, dDist1, eDist1, qDist1, oDist1, mDist1);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_hypergeometric"))
            {
                XInputArray = new[] { 0.0d, 1.0d, 3.0d, 8.0d, 10.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var r in new[] { 50 })
                {
                    foreach (var n in new[] { 30 })
                    {
                        foreach (var NN in new[] { 500 })
                        {
                            sDist1 = sreal.dist_hypergeometric((ulong)r, (ulong)n, (ulong)NN);
                            dDist1 = dreal.dist_hypergeometric((ulong)r, (ulong)n, (ulong)NN);
                            eDist1 = ereal.dist_hypergeometric((ulong)r, (ulong)n, (ulong)NN);
                            qDist1 = qreal.dist_hypergeometric((ulong)r, (ulong)n, (ulong)NN);
                            oDist1 = oreal.dist_hypergeometric((ulong)r, (ulong)n, (ulong)NN);
#if HasArbPrecNet
                            mDist1 = mreal.dist_hypergeometric((ulong)r, (ulong)n, (ulong)NN);
#endif
                            string DStr = string.Format("dist_hypergeometric(r={0}, n={1}, NN={2})", r, n, NN);
                            ShowDistLattice(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist1, dDist1, eDist1, qDist1, oDist1, mDist1);
                        }
                    }
                }
            }

            #endregion


            #region Closed form distributions, based on elementary functions


            if (DistArray.Contains("all") | DistArray.Contains("dist_arcsine"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.001, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] {0.0, -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] {1.0, 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_arcsine(a, b);
                        dDist = dreal.dist_arcsine(a, b);
                        eDist = ereal.dist_arcsine(a, b);
                        qDist = qreal.dist_arcsine(a, b);
                        oDist = oreal.dist_arcsine(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_arcsine(a, b);
#endif
                        string DStr = string.Format("dist_arcsine(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }



            if (DistArray.Contains("all") | DistArray.Contains("dist_cauchy"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_cauchy(a, b);
                        dDist = dreal.dist_cauchy(a, b);
                        eDist = ereal.dist_cauchy(a, b);
                        qDist = qreal.dist_cauchy(a, b);
                        oDist = oreal.dist_cauchy(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_cauchy(a, b);
#endif
                        string DStr = string.Format("dist_cauchy(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_exponential"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var lambda1 in new[] { 1.5d, 2.5d, 3.5d })
                {
                    sDist = sreal.dist_exponential(lambda1);
                    dDist = dreal.dist_exponential(lambda1);
                    eDist = ereal.dist_exponential(lambda1);
                    qDist = qreal.dist_exponential(lambda1);
                    oDist = oreal.dist_exponential(lambda1);
#if HasArbPrecNet
                    mDist = mreal.dist_exponential(lambda1);
#endif
                    string DStr = string.Format("dist_exponential(lambda1={0})", lambda1);
                    ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_gumbel"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_gumbel(a, b);
                        dDist = dreal.dist_gumbel(a, b);
                        eDist = ereal.dist_gumbel(a, b);
                        qDist = qreal.dist_gumbel(a, b);
                        oDist = oreal.dist_gumbel(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_gumbel(a, b);
#endif
                        string DStr = string.Format("dist_gumbel(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_hyperexponential"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };

                //α = (0.2, 0.3, 0.5) and λ = (0.5, 1.0, 1.5)
                double a1 = 0.2; double l1 = 0.5;
                double a2 = 0.3; double l2 = 1.0;
                double a3 = 0.5; double l3 = 1.5;
                sDist = sreal.dist_hyperexponential(sreal.VecParams(a1, a2, a3), sreal.VecParams(l1, l2, l3));
                dDist = dreal.dist_hyperexponential(dreal.VecParams(a1, a2, a3), dreal.VecParams(l1, l2, l3));
                eDist = ereal.dist_hyperexponential(ereal.VecParams(a1, a2, a3), ereal.VecParams(l1, l2, l3));
                qDist = qreal.dist_hyperexponential(qreal.VecParams(a1, a2, a3), qreal.VecParams(l1, l2, l3));
                oDist = oreal.dist_hyperexponential(oreal.VecParams(a1, a2, a3), oreal.VecParams(l1, l2, l3));
#if HasArbPrecNet
                mDist = mreal.dist_hyperexponential(mreal.VecParams(a1, a2, a3), mreal.VecParams(l1, l2, l3));
#endif
                string DStr = string.Format("dist_hyperexponential(a={0}, b={1})", "a", "b");
                ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
            }



            if (DistArray.Contains("all") | DistArray.Contains("dist_kumaraswamy"))
            {
                XInputArray = new[] { 0.01d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_kumaraswamy(a, b);
                        dDist = dreal.dist_kumaraswamy(a, b);
                        eDist = ereal.dist_kumaraswamy(a, b);
                        qDist = qreal.dist_kumaraswamy(a, b);
                        oDist = oreal.dist_kumaraswamy(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_kumaraswamy(a, b);
#endif
                        string DStr = string.Format("dist_kumaraswamy(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);

                    }
                }
            }



            if (DistArray.Contains("all") | DistArray.Contains("dist_laplace"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_laplace(a, b);
                        dDist = dreal.dist_laplace(a, b);
                        eDist = ereal.dist_laplace(a, b);
                        qDist = qreal.dist_laplace(a, b);
                        oDist = oreal.dist_laplace(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_laplace(a, b);
#endif
                        string DStr = string.Format("dist_laplace(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);

                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_logistic"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_logistic(a, b);
                        dDist = dreal.dist_logistic(a, b);
                        eDist = ereal.dist_logistic(a, b);
                        qDist = qreal.dist_logistic(a, b);
                        oDist = oreal.dist_logistic(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_logistic(a, b);
#endif
                        string DStr = string.Format("dist_logistic(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_pareto"))
            {
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var k in new[] { 1.5d, 2.5d, 3.5d })
                {
                    XInputArray = new[] { 0.0d+k, 0.333d+k, 0.75d+k, 1.0d+k };
                    foreach (var a in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_pareto(k, a);
                        dDist = dreal.dist_pareto(k, a);
                        eDist = ereal.dist_pareto(k, a);
                        qDist = qreal.dist_pareto(k, a);
                        oDist = oreal.dist_pareto(k, a);
#if HasArbPrecNet
                        mDist = mreal.dist_pareto(k, a);
#endif
                        string DStr = string.Format("dist_pareto(k={0}, a={1})", k, a);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_rayleigh"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var b in new[] { 1.5d, 2.5d, 3.5d })
                {
                    sDist = sreal.dist_rayleigh(b);
                    dDist = dreal.dist_rayleigh(b);
                    eDist = ereal.dist_rayleigh(b);
                    qDist = qreal.dist_rayleigh(b);
                    oDist = oreal.dist_rayleigh(b);
#if HasArbPrecNet
                    mDist = mreal.dist_rayleigh(b);
#endif
                    string DStr = string.Format("dist_rayleigh(b={0})", b);
                    ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_triangular"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var m in new[] { 1.5d, 2.5d, 3.5d })
                    {
                        foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                        {
                            sDist = sreal.dist_triangular(a, m, b);
                            dDist = dreal.dist_triangular(a, m, b);
                            eDist = ereal.dist_triangular(a, m, b);
                            qDist = qreal.dist_triangular(a, m, b);
                            oDist = oreal.dist_triangular(a, m, b);
#if HasArbPrecNet
                            mDist = mreal.dist_triangular(a, m, b);
#endif
                            string DStr = string.Format("dist_triangular(a={0}, m={1}, b={2})", a, m, b);
                            ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);

                        }
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_uniform"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_uniform(a, b);
                        dDist = dreal.dist_uniform(a, b);
                        eDist = ereal.dist_uniform(a, b);
                        qDist = qreal.dist_uniform(a, b);
                        oDist = oreal.dist_uniform(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_uniform(a, b);
#endif
                        string DStr = string.Format("dist_uniform(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_weibull"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_weibull(a, b);
                        dDist = dreal.dist_weibull(a, b);
                        eDist = ereal.dist_weibull(a, b);
                        qDist = qreal.dist_weibull(a, b);
                        oDist = oreal.dist_weibull(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_weibull(a, b);
#endif
                        string DStr = string.Format("dist_weibull(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            #endregion


            #region Closed form distributions, based on the error function


            if (DistArray.Contains("all") | DistArray.Contains("dist_levy"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_levy(a, b);
                        dDist = dreal.dist_levy(a, b);
                        eDist = ereal.dist_levy(a, b);
                        qDist = qreal.dist_levy(a, b);
                        oDist = oreal.dist_levy(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_levy(a, b);
#endif
                        string DStr = string.Format("dist_levy(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_lognormal"))
            {
                XInputArray = new[] { 0.0, 1.0 , 10.0, 100.0, 1000.0, dreal.inf()};
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_lognormal(a, b);
                        dDist = dreal.dist_lognormal(a, b);
                        eDist = ereal.dist_lognormal(a, b);
                        qDist = qreal.dist_lognormal(a, b);
                        oDist = oreal.dist_lognormal(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_lognormal(a, b);
#endif
                        string DStr = string.Format("dist_lognormal(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_moyal"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_moyal(a, b);
                        dDist = dreal.dist_moyal(a, b);
                        eDist = ereal.dist_moyal(a, b);
                        qDist = qreal.dist_moyal(a, b);
                        oDist = oreal.dist_moyal(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_moyal(a, b);
#endif
                        string DStr = string.Format("dist_moyal(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }




            if (DistArray.Contains("all") | DistArray.Contains("dist_normal"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var mu in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var sigma in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_normal(mu, sigma);
                        dDist = dreal.dist_normal(mu, sigma);
                        eDist = ereal.dist_normal(mu, sigma);
                        qDist = qreal.dist_normal(mu, sigma);
                        oDist = oreal.dist_normal(mu, sigma);
#if HasArbPrecNet
                        mDist = mreal.dist_normal(mu, sigma);
#endif
                        string DStr = string.Format("dist_normal(mu={0}, sigma={1})", mu, sigma);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_skewnormal"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        foreach (var c in new[] { 1.5d, 2.5d, 3.5d })
                        {
                            sDist = sreal.dist_skewnormal(a, b, c);
                            dDist = dreal.dist_skewnormal(a, b, c);
                            eDist = ereal.dist_skewnormal(a, b, c);
                            qDist = qreal.dist_skewnormal(a, b, c);
                            oDist = oreal.dist_skewnormal(a, b, c);
#if HasArbPrecNet
                            mDist = mreal.dist_skewnormal(a, b, c);
#endif
                            string DStr = string.Format("dist_skewnormal(a={0}, b={1}, c={2})", a, b, c);
                            ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                        }
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_wald"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var mu in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_wald(mu, b);
                        dDist = dreal.dist_wald(mu, b);
                        eDist = ereal.dist_wald(mu, b);
                        qDist = qreal.dist_wald(mu, b);
                        oDist = oreal.dist_wald(mu, b);
#if HasArbPrecNet
                        mDist = mreal.dist_wald(mu, b);
#endif
                        string DStr = string.Format("dist_Wald(mu={0}, b={1})", mu, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }



            #endregion


            #region Closed form distributions, based on the incomplete gamma function


            if (DistArray.Contains("all") | DistArray.Contains("dist_chi"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var n in new[] { 1.5d, 2.5d, 3.5d })
                {
                    sDist = sreal.dist_chi(n);
                    dDist = dreal.dist_chi(n);
                    eDist = ereal.dist_chi(n);
                    qDist = qreal.dist_chi(n);
                    oDist = oreal.dist_chi(n);
#if HasArbPrecNet
                    mDist = mreal.dist_chi(n);
#endif
                    string DStr = string.Format("dist_chi(n={0})", n);
                    ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_chi2"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var n in new[] { 1.5d, 2.5d, 3.5d })
                {
                    sDist = sreal.dist_chi2(n);
                    dDist = dreal.dist_chi2(n);
                    eDist = ereal.dist_chi2(n);
                    qDist = qreal.dist_chi2(n);
                    oDist = oreal.dist_chi2(n);
#if HasArbPrecNet
                    mDist = mreal.dist_chi2(n);
#endif
                    string DStr = string.Format("dist_chi2(n={0})", n);
                    ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_gamma"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_gamma(a, b);
                        dDist = dreal.dist_gamma(a, b);
                        eDist = ereal.dist_gamma(a, b);
                        qDist = qreal.dist_gamma(a, b);
                        oDist = oreal.dist_gamma(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_gamma(a, b);
#endif
                        string DStr = string.Format("dist_gamma(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_inverse_chi2"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_inverse_chi2(a, b);
                        dDist = dreal.dist_inverse_chi2(a, b);
                        eDist = ereal.dist_inverse_chi2(a, b);
                        qDist = qreal.dist_inverse_chi2(a, b);
                        oDist = oreal.dist_inverse_chi2(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_inverse_chi2(a, b);
#endif
                        string DStr = string.Format("dist_inverse_chi2(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_inverse_gamma"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_inverse_gamma(a, b);
                        dDist = dreal.dist_inverse_gamma(a, b);
                        eDist = ereal.dist_inverse_gamma(a, b);
                        qDist = qreal.dist_inverse_gamma(a, b);
                        oDist = oreal.dist_inverse_gamma(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_inverse_gamma(a, b);
#endif
                        string DStr = string.Format("dist_inverse_gamma(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_maxwell"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var b in new[] { 1.5d, 2.5d, 3.5d })
                {
                    sDist = sreal.dist_maxwell(b);
                    dDist = dreal.dist_maxwell(b);
                    eDist = ereal.dist_maxwell(b);
                    qDist = qreal.dist_maxwell(b);
                    oDist = oreal.dist_maxwell(b);
#if HasArbPrecNet
                    mDist = mreal.dist_maxwell(b);
#endif
                    string DStr = string.Format("dist_maxwell(b={0})", b);
                    ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_nakagami"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_nakagami(a, b);
                        dDist = dreal.dist_nakagami(a, b);
                        eDist = ereal.dist_nakagami(a, b);
                        qDist = qreal.dist_nakagami(a, b);
                        oDist = oreal.dist_nakagami(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_nakagami(a, b);
#endif
                        string DStr = string.Format("dist_nakagami(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            #endregion


            #region Closed form distributions, based on the incomplete beta function


            if (DistArray.Contains("all") | DistArray.Contains("dist_beta"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_beta(a, b);
                        dDist = dreal.dist_beta(a, b);
                        eDist = ereal.dist_beta(a, b);
                        qDist = qreal.dist_beta(a, b);
                        oDist = oreal.dist_beta(a, b);
#if HasArbPrecNet
                        mDist = mreal.dist_beta(a, b);
#endif
                        string DStr = string.Format("dist_beta(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_fisher_f"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var m in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var n in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_fisher_f(m, n);
                        dDist = dreal.dist_fisher_f(m, n);
                        eDist = ereal.dist_fisher_f(m, n);
                        qDist = qreal.dist_fisher_f(m, n);
                        oDist = oreal.dist_fisher_f(m, n);
#if HasArbPrecNet
                        mDist = mreal.dist_fisher_f(m, n);
#endif
                        string DStr = string.Format("dist_fisher_f(m={0}, n={1})", m, n);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_student_t"))
            {
                //XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                XInputArray = new[] { 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var n in new[] { 1.5d, 2.5d, 3.5d })
                {
                    sDist = sreal.dist_student_t(n);
                    dDist = dreal.dist_student_t(n);
                    eDist = ereal.dist_student_t(n);
                    qDist = qreal.dist_student_t(n);
                    oDist = oreal.dist_student_t(n);
#if HasArbPrecNet
                    mDist = mreal.dist_student_t(n);
#endif
                    string DStr = string.Format("dist_student_t(n={0})", n);
                    ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                }
            }



            #endregion


            #region Non-central distribution functions


            if (DistArray.Contains("all") | DistArray.Contains("dist_chi2_nc"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var n in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var lambda1 in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_chi2_nc(n, lambda1);
                        dDist = dreal.dist_chi2_nc(n, lambda1);
                        eDist = ereal.dist_chi2_nc(n, lambda1);
                        qDist = qreal.dist_chi2_nc(n, lambda1);
                        oDist = oreal.dist_chi2_nc(n, lambda1);
#if HasArbPrecNet
                        mDist = mreal.dist_chi2_nc(n, lambda1);
#endif
                        string DStr = string.Format("dist_chi2_nc(n={0}, lambda1={1})", n, lambda1);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_Student_t_nc"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var n in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var delta in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_student_t_nc(n, delta);
                        dDist = dreal.dist_student_t_nc(n, delta);
                        eDist = ereal.dist_student_t_nc(n, delta);
                        qDist = qreal.dist_student_t_nc(n, delta);
                        oDist = oreal.dist_student_t_nc(n, delta);
#if HasArbPrecNet
                        mDist = mreal.dist_student_t_nc(n, delta);
#endif
                        string DStr = string.Format("dist_Student_t_nc(n={0}, delta={1})", n, delta);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_fisher_f_nc"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var m in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var n in new[] { 11.5d, 12.5d, 13.5d })
                    {
                        foreach (var lambda1 in new[] { 5.1d, 12.1d, 53.5d })
                        {
                            sDist = sreal.dist_fisher_f_nc(m, n, lambda1);
                            dDist = dreal.dist_fisher_f_nc(m, n, lambda1);
                            eDist = ereal.dist_fisher_f_nc(m, n, lambda1);
                            qDist = qreal.dist_fisher_f_nc(m, n, lambda1);
                            oDist = oreal.dist_fisher_f_nc(m, n, lambda1);
#if HasArbPrecNet
                            mDist = mreal.dist_fisher_f_nc(m, n, lambda1);
#endif
                            string DStr = string.Format("dist_fisher_f_nc(m={0}, n={1}, lambda1={2})", m, n, lambda1);
                            ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                        }
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_beta_nc"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { 1.5d, 2.5d, 3.5d })
                {
                    foreach (var b in new[] { 11.5d, 12.5d, 13.5d })
                    {
                        foreach (var lambda1 in new[] { 5.1d, 12.1d, 53.5d })
                        {
                            sDist = sreal.dist_beta_nc(a, b, lambda1);
                            dDist = dreal.dist_beta_nc(a, b, lambda1);
                            eDist = ereal.dist_beta_nc(a, b, lambda1);
                            qDist = qreal.dist_beta_nc(a, b, lambda1);
                            oDist = oreal.dist_beta_nc(a, b, lambda1);
#if HasArbPrecNet
                            mDist = mreal.dist_beta_nc(a, b, lambda1);
#endif
                            string DStr = string.Format("dist_beta_nc(a={0}, b={1}, lambda1={2})", a, b, lambda1);
                            ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                        }
                    }
                }
            }

            #endregion


            #region Miscellaneous continuous distributions


            if (DistArray.Contains("all") | DistArray.Contains("dist_kolmogorov_smirnov"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var n in new[] { 11, 25, 35 })
                {
                    sDist = sreal.dist_kolmogorov_smirnov(n);
                    dDist = dreal.dist_kolmogorov_smirnov(n);
                    eDist = ereal.dist_kolmogorov_smirnov(n);
                    qDist = qreal.dist_kolmogorov_smirnov(n);
                    oDist = null;
#if HasArbPrecNet
                    mDist = null;
#endif
                    string DStr = string.Format("dist_kolmogorov_smirnov(n={0})", n);
                    ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                }
            }



            if (DistArray.Contains("all") | DistArray.Contains("dist_holtsmark"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_holtsmark(a, b);
                        dDist = dreal.dist_holtsmark(a, b);
                        eDist = ereal.dist_holtsmark(a, b);
                        qDist = qreal.dist_holtsmark(a, b);
                        oDist = null;
#if HasArbPrecNet
                        mDist = null;
#endif
                        string DStr = string.Format("dist_holtsmark(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_landau"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_landau(a, b);
                        dDist = dreal.dist_landau(a, b);
                        eDist = ereal.dist_landau(a, b);
                        qDist = qreal.dist_landau(a, b);
                        oDist = null;
#if HasArbPrecNet
                        mDist = null;
#endif
                        string DStr = string.Format("dist_landau(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_mapairy"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_mapairy(a, b);
                        dDist = dreal.dist_mapairy(a, b);
                        eDist = ereal.dist_mapairy(a, b);
                        qDist = qreal.dist_mapairy(a, b);
                        oDist = null;
#if HasArbPrecNet
                        mDist = null;
#endif
                        string DStr = string.Format("dist_mapairy(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }


            if (DistArray.Contains("all") | DistArray.Contains("dist_saspoint5"))
            {
                XInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                QInputArray = new[] { 0.0d, 0.333d, 0.75d, 1.0d };
                foreach (var a in new[] { -1.5d, -2.5d, -3.5d })
                {
                    foreach (var b in new[] { 5.1d, 12.1d, 53.5d })
                    {
                        sDist = sreal.dist_saspoint5(a, b);
                        dDist = dreal.dist_saspoint5(a, b);
                        eDist = ereal.dist_saspoint5(a, b);
                        qDist = qreal.dist_saspoint5(a, b);
                        oDist = null;
#if HasArbPrecNet
                        mDist = null;
#endif
                        string DStr = string.Format("dist_saspoint5(a={0}, b={1})", a, b);
                        ShowDistCont(DStr, XInputArray, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
                    }
                }
            }



            #endregion

        }




        #region Supporting functions


        //public static string f(string NumType)
        //{
        //    return (NumType == "aflint") ? "" : " ";
        //}



        public static void DistGenXLattice(string DStr, double[] XInputArray, string[] NumTypeArray, string[] FunctionArray, sreal.BaseDistDiscreteClass sDist, dreal.BaseDistDiscreteClass dDist, ereal.BaseDistDiscreteClass eDist, qreal.BaseDistDiscreteClass qDist, oreal.BaseDistDiscreteClass oDist, mDistDiscreteClass mDist)
        {
            foreach (var x in XInputArray)
            {
                if (FunctionArray.Contains("all") | FunctionArray.Contains("pmf"))
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        dynamic res1 = "Not done";
                        switch (NumType)
                        {
                            case " sreal": { if (sDist != null) res1 = sDist.pmf(x); break; }
                            case " dreal": { if (dDist != null) res1 = dDist.pmf(x); break; }
                            case " ereal": { if (eDist != null) res1 = eDist.pmf(x); break; }
                            case " qreal": { if (qDist != null) res1 = qDist.pmf(x); break; }
                            case " oreal": { if (oDist != null) res1 = oDist.pmf(x); break; }
#if HasArbPrecNet
                            case " mreal": { if (mDist != null) res1 = mDist.pmf(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: {1}.pmf(x={2}): " + f(NumType) + "{3}", NumType, DStr, x, res1);
                    }
                }
            }
            if (FunctionArray.Contains("pmf")) Console.WriteLine();
        }



        public static void DistGenXCont(string DStr, double[] XInputArray, string[] NumTypeArray, string[] FunctionArray, sreal.BaseDistContClass sDist, dreal.BaseDistContClass dDist, ereal.BaseDistContClass eDist, qreal.BaseDistContClass qDist, oreal.BaseDistContClass oDist, mDistContClass mDist)
        {
            foreach (var x in XInputArray)
            {
                if (FunctionArray.Contains("all") | FunctionArray.Contains("pdf"))
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        dynamic res1 = "Not done";
                        switch (NumType)
                        {
                            case " sreal": { if (sDist != null) res1 = sDist.pdf(x); break; }
                            case " dreal": { if (dDist != null) res1 = dDist.pdf(x); break; }
                            case " ereal": { if (eDist != null) res1 = eDist.pdf(x); break; }
                            case " qreal": { if (qDist != null) res1 = qDist.pdf(x); break; }
                            case " oreal": { if (oDist != null) res1 = oDist.pdf(x); break; }
#if HasArbPrecNet
                            case " mreal": { if (mDist != null) res1 = mDist.pdf(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: {1}.pdf(x={2}): " + f(NumType) + "{3}", NumType, DStr, x, res1);
                    }
                }
            }
            if (FunctionArray.Contains("pdf")) Console.WriteLine();
        }


        public static void DistGenX(string DStr, double[] XInputArray, string[] NumTypeArray, string[] FunctionArray, sreal.BaseDistClass sDist, dreal.BaseDistClass dDist, ereal.BaseDistClass eDist, qreal.BaseDistClass qDist, oreal.BaseDistClass oDist, mDistClass mDist)
        {

            foreach (var x in XInputArray)
            {
                if (FunctionArray.Contains("all") | FunctionArray.Contains("cdf"))
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        dynamic res1 = "Not done";
                        switch (NumType)
                        {
                            case " sreal": { if (sDist != null) res1 = sDist.cdf(x); break; }
                            case " dreal": { if (dDist != null) res1 = dDist.cdf(x); break; }
                            case " ereal": { if (eDist != null) res1 = eDist.cdf(x); break; }
                            case " qreal": { if (qDist != null) res1 = qDist.cdf(x); break; }
                            case " oreal": { if (oDist != null) res1 = oDist.cdf(x); break; }
#if HasArbPrecNet
                            case " mreal": { if (mDist != null) res1 = mDist.cdf(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: {1}.cdf(x={2}): " + f(NumType) + "{3}", NumType, DStr, x, res1);
                    }
                }
            }
            if (FunctionArray.Contains("cdf")) Console.WriteLine();

            foreach (var x in XInputArray)
            {
                if (FunctionArray.Contains("all") | FunctionArray.Contains("sf"))
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        dynamic res1 = "Not done";
                        switch (NumType)
                        {
                            case " sreal": { if (sDist != null) res1 = sDist.sf(x); break; }
                            case " dreal": { if (dDist != null) res1 = dDist.sf(x); break; }
                            case " ereal": { if (eDist != null) res1 = eDist.sf(x); break; }
                            case " qreal": { if (qDist != null) res1 = qDist.sf(x); break; }
                            case " oreal": { if (oDist != null) res1 = oDist.sf(x); break; }
#if HasArbPrecNet
                            case " mreal": { if (mDist != null) res1 = mDist.sf(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: {1}.sf(x={2}): " + f(NumType) + "{3}", NumType, DStr, x, res1);
                    }
                }
            }
            if (FunctionArray.Contains("sf")) Console.WriteLine();

            foreach (var x in XInputArray)
            {
                if (FunctionArray.Contains("all") | FunctionArray.Contains("hf"))
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        dynamic res1 = "Not done";
                        switch (NumType)
                        {
                            case " sreal": { if (sDist != null) res1 = sDist.hf(x); break; }
                            case " dreal": { if (dDist != null) res1 = dDist.hf(x); break; }
                            case " ereal": { if (eDist != null) res1 = eDist.hf(x); break; }
                            case " qreal": { if (qDist != null) res1 = qDist.hf(x); break; }
                            case " oreal": { if (oDist != null) res1 = oDist.hf(x); break; }
#if HasArbPrecNet
                            case " mreal": { if (mDist != null) res1 = mDist.hf(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: {1}.hf(x={2}): " + f(NumType) + "{3}", NumType, DStr, x, res1);
                    }
                }
            }
            if (FunctionArray.Contains("hf")) Console.WriteLine();

            foreach (var x in XInputArray)
            {
                if (FunctionArray.Contains("all") | FunctionArray.Contains("chf"))
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        dynamic res1 = "Not done";
                        switch (NumType)
                        {
                            case " sreal": { if (sDist != null) res1 = sDist.chf(x); break; }
                            case " dreal": { if (dDist != null) res1 = dDist.chf(x); break; }
                            case " ereal": { if (eDist != null) res1 = eDist.chf(x); break; }
                            case " qreal": { if (qDist != null) res1 = qDist.chf(x); break; }
                            case " oreal": { if (oDist != null) res1 = oDist.chf(x); break; }
#if HasArbPrecNet
                            case " mreal": { if (mDist != null) res1 = mDist.chf(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: {1}.chf(x={2}): " + f(NumType) + "{3}", NumType, DStr, x, res1);
                    }
                }
            }
            if (FunctionArray.Contains("chf")) Console.WriteLine();
        }


        public static void DistGenQ(string DStr, double[] QInputArray, string[] NumTypeArray, string[] FunctionArray, sreal.BaseDistClass sDist, dreal.BaseDistClass dDist, ereal.BaseDistClass eDist, qreal.BaseDistClass qDist, oreal.BaseDistClass oDist, mDistClass mDist)
        {
            foreach (var q in QInputArray)
            {
                if (FunctionArray.Contains("all") | FunctionArray.Contains("qtf"))
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        dynamic res1 = "Not done";
                        switch (NumType)
                        {
                            case " sreal": { if (sDist != null) res1 = sDist.qtf(q); break; }
                            case " dreal": { if (dDist != null) res1 = dDist.qtf(q); break; }
                            case " ereal": { if (eDist != null) res1 = eDist.qtf(q); break; }
                            case " qreal": { if (qDist != null) res1 = qDist.qtf(q); break; }
                            case " oreal": { if (oDist != null) res1 = oDist.qtf(q); break; }
#if HasArbPrecNet
                            case " mreal": { if (mDist != null) res1 = mDist.qtf(q); break; }
#endif
                        }
                        Console.WriteLine("{0}: {1}.qtf(q={2}): " + f(NumType) + "{3}", NumType, DStr, q, res1);
                    }
                }
            }
            if (FunctionArray.Contains("qtf")) Console.WriteLine();

            foreach (var q in QInputArray)
            {
                if (FunctionArray.Contains("all") | FunctionArray.Contains("isf"))
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        dynamic res1 = "Not done";
                        switch (NumType)
                        {
                            case " sreal": { if (sDist != null) res1 = sDist.isf(q); break; }
                            case " dreal": { if (dDist != null) res1 = dDist.isf(q); break; }
                            case " ereal": { if (eDist != null) res1 = eDist.isf(q); break; }
                            case " qreal": { if (qDist != null) res1 = qDist.isf(q); break; }
                            case " oreal": { if (oDist != null) res1 = oDist.isf(q); break; }
#if HasArbPrecNet
                            case " mreal": { if (mDist != null) res1 = mDist.isf(q); break; }
#endif
                        }
                        Console.WriteLine("{0}: {1}.isf(q={2}): " + f(NumType) + "{3}", NumType, DStr, q, res1);
                    }
                }
            }
            if (FunctionArray.Contains("isf")) Console.WriteLine();

        }



        public static void DistGen(string DStr, string[] NumTypeArray, string[] FunctionArray, sreal.BaseDistClass sDist, dreal.BaseDistClass dDist, ereal.BaseDistClass eDist, qreal.BaseDistClass qDist, oreal.BaseDistClass oDist, mDistClass mDist)
        {
            if (FunctionArray.Contains("all") | FunctionArray.Contains("mean"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.mean(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.mean(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.mean(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.mean(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.mean(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.mean(); break; }
#endif
                    }
                    Console.WriteLine("{0}: {1}.mean(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("median"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.median(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.median(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.median(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.median(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.median(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.median(); break; }
#endif
                    }
                    Console.WriteLine("{0}: {1}.median(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("mode"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.mode(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.mode(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.mode(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.mode(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.mode(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.mode(); break; }
#endif
                    }
                    Console.WriteLine("{0}: {1}.mode(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("variance"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.variance(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.variance(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.variance(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.variance(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.variance(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.variance(); break; }
#endif
                    }
                    Console.WriteLine("{0}: {1}.variance(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("stdev"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.stdev(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.stdev(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.stdev(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.stdev(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.stdev(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.stdev(); break; }
#endif
                    }
                    Console.WriteLine("{0}: {1}.stdev(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("skewness"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.skewness(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.skewness(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.skewness(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.skewness(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.skewness(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.skewness(); break; }
#endif
                    }
                    Console.WriteLine("{0}: {1}.skewness(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("kurtosis"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.kurtosis(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.kurtosis(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.kurtosis(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.kurtosis(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.kurtosis(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.kurtosis(); break; }
#endif
                    }
                    Console.WriteLine("{0}: {1}.kurtosis(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("kurtosis_excess"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.kurtosis_excess(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.kurtosis_excess(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.kurtosis_excess(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.kurtosis_excess(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.kurtosis_excess(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.kurtosis_excess(); break; }
#endif
                    }
                    Console.WriteLine("{0}: {1}.kurtosis_excess(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("support_lower_endpoint"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.support_lower_endpoint(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.support_lower_endpoint(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.support_lower_endpoint(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.support_lower_endpoint(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.support_lower_endpoint(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.support_lower_endpoint(); break; }

#endif
                    }
                    Console.WriteLine("{0}: {1}.support_lower_endpoint(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("support_upper_endpoint"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.support_upper_endpoint(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.support_upper_endpoint(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.support_upper_endpoint(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.support_upper_endpoint(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.support_upper_endpoint(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.support_upper_endpoint(); break; }
#endif
                    }
                    Console.WriteLine("{0}: {1}.support_upper_endpoint(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("range_lower_endpoint"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.range_lower_endpoint(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.range_lower_endpoint(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.range_lower_endpoint(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.range_lower_endpoint(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.range_lower_endpoint(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.range_lower_endpoint(); break; }
#endif
                    }
                    Console.WriteLine("{0}: {1}.range_lower_endpoint(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("range_upper_endpoint"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    dynamic res1 = "Not done";
                    switch (NumType)
                    {
                        case " sreal": { if (sDist != null) res1 = sDist.range_upper_endpoint(); break; }
                        case " dreal": { if (dDist != null) res1 = dDist.range_upper_endpoint(); break; }
                        case " ereal": { if (eDist != null) res1 = eDist.range_upper_endpoint(); break; }
                        case " qreal": { if (qDist != null) res1 = qDist.range_upper_endpoint(); break; }
                        case " oreal": { if (oDist != null) res1 = oDist.range_upper_endpoint(); break; }
#if HasArbPrecNet
                        case " mreal": { if (mDist != null) res1 = mDist.range_upper_endpoint(); break; }
#endif
                    }
                    Console.WriteLine("{0}: {1}.range_upper_endpoint(): " + f(NumType) + "{2}", NumType, DStr, res1);
                }
            }

        }


        public static void ShowDistCont(string DStr, double[] XInputArray, double[] QInputArray, string[] NumTypeArray, string[] FunctionArray, sreal.BaseDistContClass sDist, dreal.BaseDistContClass dDist, ereal.BaseDistContClass eDist, qreal.BaseDistContClass qDist, oreal.BaseDistContClass oDist, mDistContClass mDist)
        {
            DistGenXCont(DStr, XInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
            DistGenX(DStr, XInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
            DistGenQ(DStr, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
            DistGen(DStr, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
        }


        public static void ShowDistLattice(string DStr, double[] XInputArray, double[] QInputArray, string[] NumTypeArray, string[] FunctionArray, sreal.BaseDistDiscreteClass sDist, dreal.BaseDistDiscreteClass dDist, ereal.BaseDistDiscreteClass eDist, qreal.BaseDistDiscreteClass qDist, oreal.BaseDistDiscreteClass oDist, mDistDiscreteClass mDist)
        {
            DistGenXLattice(DStr, XInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
            DistGenX(DStr, XInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
            DistGenQ(DStr, QInputArray, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
            DistGen(DStr, NumTypeArray, FunctionArray, sDist, dDist, eDist, qDist, oDist, mDist);
        }

        #endregion




        #endregion




        public static void Distributions()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTestsDistributions();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10d);
            Console.WriteLine("Elapsed Time " + elapsedTime);
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Memory used before collection: {0:N0}", GC.GetTotalMemory(false));
            GC.Collect();
            Console.WriteLine("Memory used after full collection: {0:N0}", GC.GetTotalMemory(true));
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("");
        }




    }
}