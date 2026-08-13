# -*- coding: utf-8 -*-

from xlcalcnet.mpmath import plot

from xlcalcnet import mpm, ipm, dpm

useplot = False


#  5.1 Closed form distributions, based on elementary functions

def demo_5_1_part1_closed_form_elementary(ctx):


    # 5.1.1 Arcsine distribution, pdf
    def demo_arcsine_pdf(ctx):
        print("demo_arcsine_pdf")
        if useplot: plot(lambda x: mpm.arcsine_pdf(x), [0, 1])
        return


    # 5.1.2 Arcsine distribution, cdf and sf
    def demo_arcsine_cdf(ctx):
        print("demo_arcsine_cdf")
        if useplot: plot(lambda x: mpm.arcsine_cdf(x), [0, 1])
        print("demo_arcsine_sf")
        if useplot: plot(lambda x: mpm.arcsine_cdf(x, 0, 1, False), [0, 1])
        return


    # 5.1.3 Arcsine distribution, qtf and isf
    def demo_arcsine_qtf(ctx):
        print("demo_arcsine_qtf")
        if useplot: plot(lambda q: mpm.arcsine_qtf(q), [0, 1])
        print("demo_arcsine_isf")
        if useplot: plot(lambda q: mpm.arcsine_qtf(q, 0, 1, False), [0, 1])
        return


    # 5.1.4 Cauchy distribution, pdf
    def demo_cauchy_pdf(ctx):
        print("demo_cauchy_pdf")
        a=0; b=2
        if useplot: plot(lambda x: mpm.cauchy_pdf(x,a,b), [-10, 10])
        return


    # 5.1.5 Cauchy distribution, cdf and sf
    def demo_cauchy_cdf(ctx):
        print("demo_cauchy_cdf")
        a=0; b=2
        if useplot: plot(lambda x: mpm.cauchy_cdf(x,a,b), [-10, 10])
        print("demo_cauchy_sf")
        if useplot: plot(lambda x: mpm.cauchy_cdf(x,a,b,False), [-10, 10])
        return


    # 5.1.6 Cauchy distribution, qtf and isf
    def demo_cauchy_qtf(ctx):
        print("demo_cauchy_qtf")
        a=0; b=2
        if useplot: plot(lambda q: mpm.cauchy_qtf(q,a,b), [0.01, 1-0.01])
        print("demo_cauchy_isf")
        if useplot: plot(lambda q: mpm.cauchy_qtf(q,a,b,False), [0.01, 1-0.01])
        return


    # 5.1.7 Dagum distribution, pdf
    def demo_dagum_pdf(ctx):
        print("demo_dagum_pdf")
        a=2; b=2; p=1
        if useplot: plot(lambda x: mpm.dagum_pdf(x,a,b,p), [0, 10])
        return


    # 5.1.8 Dagum distribution, cdf and sf
    def demo_dagum_cdf(ctx):
        print("demo_dagum_cdf")
        a=2; b=2; p=1
        if useplot: plot(lambda x: mpm.dagum_cdf(x,a,b,p), [0, 10])
        print("demo_dagum_sf")
        if useplot: plot(lambda x: mpm.dagum_cdf(x,a,b,p, False), [0, 10])
        return


    # 5.1.9 Dagum distribution, qtf and isf
    def demo_dagum_qtf(ctx):
        print("demo_dagum_qtf")
        a=2; b=2; p=1
        if useplot: plot(lambda q: mpm.dagum_qtf(q,a,b,p), [0, 1])
        print("demo_dagum_isf")
        if useplot: plot(lambda q: mpm.dagum_qtf(q,a,b,p, False), [0, 1])
        return


    # 5.1.10 Exponential distribution, pdf
    def demo_exponential_pdf(ctx):
        print("demo_exponential_pdf")
        lambda1=2;
        if useplot: plot(lambda x: mpm.exponential_pdf(x,lambda1), [0, 10])
        return


    # 5.1.11 Exponential distribution, cdf and sf
    def demo_exponential_cdf(ctx):
        print("demo_exponential_cdf")
        lambda1=2;
        if useplot: plot(lambda x: mpm.exponential_cdf(x,lambda1), [0, 10])
        print("demo_exponential_sf")
        if useplot: plot(lambda x: mpm.exponential_cdf(x,lambda1, False), [0, 10])
        return


    # 5.1.12 Exponential distribution, qtf and isf
    def demo_exponential_qtf(ctx):
        print("demo_exponential_qtf")
        lambda1=2;
        if useplot: plot(lambda q: mpm.exponential_qtf(q,lambda1), [0, 1])
        print("demo_exponential_isf")
        if useplot: plot(lambda q: mpm.exponential_qtf(q,lambda1, False), [0, 1])
        return


    # 5.1.13 Fisk distribution, pdf
    def demo_fisk_pdf(ctx):
        print("demo_fisk_pdf")
        a=2; b=2
        if useplot: plot(lambda x: mpm.fisk_pdf(x,a,b), [0, 10])
        return


    # 5.1.14 Fisk distribution, cdf and sf
    def demo_fisk_cdf(ctx):
        print("demo_fisk_cdf")
        a=1; b=2
        if useplot: plot(lambda x: mpm.fisk_cdf(x,a,b), [0, 10])
        print("demo_fisk_sf")
        if useplot: plot(lambda x: mpm.fisk_cdf(x,a,b,False), [0, 10])
        return


    # 5.1.15 Fisk distribution, qtf and isf
    def demo_fisk_qtf(ctx):
        print("demo_fisk_qtf")
        a=1; b=2
        if useplot: plot(lambda q: mpm.fisk_qtf(q,a,b), [0, 1])
        print("demo_fisk_isf")
        if useplot: plot(lambda q: mpm.fisk_qtf(q,a,b,False), [0, 1])
        return


    # 5.1.16 Frechet distribution, pdf
    def demo_frechet_pdf(ctx):
        print("demo_frechet_pdf")
        a=2; b=3
        if useplot: plot(lambda x: mpm.frechet_pdf(x,a,b), [0, 10])
        return


    # 5.1.17 Frechet distribution, cdf and sf
    def demo_frechet_cdf(ctx):
        print("demo_frechet_cdf")
        a=2; b=3
        if useplot: plot(lambda x: mpm.frechet_cdf(x,a,b), [0, 10])
        print("demo_frechet_sf")
        if useplot: plot(lambda x: mpm.frechet_cdf(x,a,b,False), [0, 10])
        return


    # 5.1.18 Frechet distribution, qtf and isf
    def demo_frechet_qtf(ctx):
        print("demo_frechet_qtf: error?")
        a=2; b=3
        if useplot: plot(lambda q: mpm.frechet_qtf(q,a,b), [0, 1])
        print("demo_frechet_isf: error?")
        if useplot: plot(lambda q: mpm.frechet_qtf(q,a,b,False), [0, 1])
        return

    demo_arcsine_pdf(ctx)
    demo_arcsine_cdf(ctx)
    demo_arcsine_qtf(ctx)

    demo_cauchy_pdf(ctx)
    demo_cauchy_cdf(ctx)
    demo_cauchy_qtf(ctx)

    demo_dagum_pdf(ctx)
    demo_dagum_cdf(ctx)
    demo_dagum_qtf(ctx)

    demo_exponential_pdf(ctx)
    demo_exponential_cdf(ctx)
    demo_exponential_qtf(ctx)

    demo_fisk_pdf(ctx)
    demo_fisk_cdf(ctx)
    demo_fisk_qtf(ctx)

    demo_frechet_pdf(ctx)
    demo_frechet_cdf(ctx)
    demo_frechet_qtf(ctx)

    return


def demo_5_1_part2_closed_form_elementary(ctx):


    # 5.1.19 Generalized Extreme Value (GEV), pdf
    def demo_gev_pdf(ctx):
        print("demo_gev_pdf: missing!")
        return


    # 5.1.20 Generalized Extreme Value (GEV), cdf and sf
    def demo_gev_cdf(ctx):
        print("demo_gev_cdf missing!")
        return


    # 5.1.21 Generalized Extreme Value (GEV), qtf and isf
    def demo_gev_qtf(ctx):
        print("demo_gev_qtf missing!")
        return


    # 5.1.22 Generalized Pareto distribution, pdf
    def demo_genpareto_pdf(ctx):
        print("demo_genpareto_pdf")
        m=0; s=1; c=2;
        if useplot: plot(lambda x: mpm.genpareto_pdf(x,m,s,c), [0, 10])
        return


    # 5.1.23 Generalized Pareto distribution, cdf and sf
    def demo_genpareto_cdf(ctx):
        print("demo_genpareto_cdf")
        m=0; s=1; c=2;
        if useplot: plot(lambda x: mpm.genpareto_cdf(x,m,s,c), [0, 10])
        print("demo_genpareto_sf")
        if useplot: plot(lambda x: mpm.genpareto_cdf(x,m,s,c,False), [0, 10])
        return


    # 5.1.24 Generalized Pareto distribution, qtf and isf
    def demo_genpareto_qtf(ctx):
        print("demo_genpareto_qtf: error?")
        m=0; s=1; c=2;
        if useplot: plot(lambda q: mpm.genpareto_qtf(q,m,s,c), [0, 1])
        print("demo_genpareto_sf: error?")
        if useplot: plot(lambda q: mpm.genpareto_qtf(q,m,s,c,False), [0, 1])
        return


    # 5.1.25 Gompertz distribution, pdf
    def demo_gompertz_pdf(ctx):
        print("demo_gompertz_pdf")
        a=1; b=2; l=1.2;
        if useplot: plot(lambda x: mpm.gompertz_pdf(x,a,b,l), [0, 2])
        return


    # 5.1.26 Gompertz distribution, cdf and sf
    def demo_gompertz_cdf(ctx):
        print("demo_gompertz_cdf")
        a=1; b=2; l=1.2;
        if useplot: plot(lambda x: mpm.gompertz_cdf(x,a,b,l), [0, 2])
        print("demo_gompertz_sf")
        if useplot: plot(lambda x: mpm.gompertz_cdf(x,a,b,l,False), [0, 2])
        return


    # 5.1.27 Gompertz distribution, qtf and isf
    def demo_gompertz_qtf(ctx):
        print("demo_gompertz_qtf")
        a=1; b=2; l=1.2;
        if useplot: plot(lambda q: mpm.gompertz_cdf(q,a,b,l), [0, 1])
        print("demo_gompertz_isf")
        if useplot: plot(lambda q: mpm.gompertz_cdf(q,a,b,l,False), [0, 1])
        return


    # 5.1.28 Gumbel (Extreme Value) distribution, pdf
    def demo_gumbel_pdf(ctx):
        print("demo_gumbel_pdf")
        a=1; b=2;
        if useplot: plot(lambda x: mpm.gumbel_pdf(x,a,b), [-4, 12])
        return


    # 5.1.29 Gumbel (Extreme Value) distribution, cdf and sf
    def demo_gumbel_cdf(ctx):
        print("demo_gumbel_cdf")
        a=1; b=2;
        if useplot: plot(lambda x: mpm.gumbel_cdf(x,a,b), [-4, 12])
        print("demo_gumbel_sf")
        if useplot: plot(lambda x: mpm.gumbel_cdf(x,a,b,False), [-4, 12])
        return


    # 5.1.30 Gumbel (Extreme Value) distribution, qtf and isf
    def demo_gumbel_qtf(ctx):
        print("demo_gumbel_qtf")
        a=1; b=2;
        if useplot: plot(lambda x: mpm.gumbel_qtf(x,a,b), [0, 1])
        print("demo_gumbel_isf")
        if useplot: plot(lambda x: mpm.gumbel_qtf(x,a,b,False), [0, 1])
        return


    # 5.1.31 Hyperexponential distribution, pdf
    def demo_hyperexp_pdf(ctx):
        print("demo_hyperexp_pdf")
        k = 4
        w = [12, 5, 7, 8]
        l = [11.1,1,3,4]
        if useplot: plot(lambda x: mpm.hyperexp_pdf(x,k,w,l), [0, 2])
        return


    # 5.1.32 Hyperexponential distribution, cdf and sf
    def demo_hyperexp_cdf(ctx):
        print("demo_hyperexp_cdf")
        k = 4
        w = [12, 5, 7, 8]
        l = [11.1,1,3,4]
        if useplot: plot(lambda x: mpm.hyperexp_cdf(x,k,w,l), [0, 2])
        print("demo_hyperexp_sf")
        if useplot: plot(lambda x: mpm.hyperexp_cdf(x,k,w,l,False), [0, 2])
        return


    # 5.1.33 Hyperexponential distribution, qtf and isf
    def demo_hyperexp_qtf(ctx):
        print("demo_hyperexp_qtf")
        k = 4
        w = [12, 5, 7, 8]
        l = [11.1,1,3,4]
        if useplot: plot(lambda x: mpm.hyperexp_qtf(x,k,w,l), [0, 1])
        print("demo_hyperexp_isf")
        if useplot: plot(lambda x: mpm.hyperexp_qtf(x,k,w,l,False), [0, 1])
        return
        return


    # 5.1.34 Kumaraswamy distribution, pdf
    def demo_kumaraswamy_pdf(ctx):
        print("demo_kumaraswamy_pdf")
        a=11; b=15
        if useplot: plot(lambda x: mpm.kumaraswamy_pdf(x,a,b), [0, 1])
        return


    # 5.1.35 Kumaraswamy distribution, cdf and sf
    def demo_kumaraswamy_cdf(ctx):
        print("demo_kumaraswamy_cdf")
        a=11; b=15
        if useplot: plot(lambda x: mpm.kumaraswamy_cdf(x,a,b), [0, 1])
        print("demo_kumaraswamy_sf")
        if useplot: plot(lambda x: mpm.kumaraswamy_cdf(x,a,b,False), [0, 1])
        return


    # 5.1.36 Kumaraswamy distribution, qtf and isf
    def demo_kumaraswamy_qtf(ctx):
        print("demo_kumaraswamy_qtf, error?")
        a=11; b=15
        if useplot: plot(lambda q: mpm.kumaraswamy_qtf(q,a,b), [0, 1])
        print("demo_kumaraswamy_sf, error?")
        if useplot: plot(lambda q: mpm.kumaraswamy_qtf(q,a,b,False), [0, 1])
        return


    demo_gev_pdf(ctx)    #  missing!
    demo_gev_cdf(ctx)    #  missing!
    demo_gev_qtf(ctx)    #  missing!

    demo_genpareto_pdf(ctx)
    demo_genpareto_cdf(ctx)
    demo_genpareto_qtf(ctx)    #  error?

    demo_gompertz_pdf(ctx)
    demo_gompertz_cdf(ctx)
    demo_gompertz_qtf(ctx)

    demo_gumbel_pdf(ctx)
    demo_gumbel_cdf(ctx)
    demo_gumbel_qtf(ctx)

    demo_hyperexp_pdf(ctx)
    demo_hyperexp_cdf(ctx)
    demo_hyperexp_qtf(ctx)

    demo_kumaraswamy_pdf(ctx)
    demo_kumaraswamy_cdf(ctx)
    demo_kumaraswamy_qtf(ctx)    #  error?


    return


def demo_5_1_part3_closed_form_elementary(ctx):



    # 5.1.37 Laplace distribution, pdf
    def demo_laplace_pdf(ctx):
        print("demo_laplace_pdf")
        a=1; b=2
        if useplot: plot(lambda x: mpm.laplace_pdf(x,a,b), [-10, 10])
        return


    # 5.1.38 Laplace distribution, cdf and sf
    def demo_laplace_cdf(ctx):
        print("demo_laplace_cdf")
        a=1; b=2
        if useplot: plot(lambda x: mpm.laplace_cdf(x,a,b), [-10, 10])
        print("demo_laplace_sf")
        if useplot: plot(lambda x: mpm.laplace_cdf(x,a,b,False), [-10, 10])
        return


    # 5.1.39 Laplace distribution, qtf and isf
    def demo_laplace_qtf(ctx):
        print("demo_laplace_qtf")
        a=1; b=2
        if useplot: plot(lambda q: mpm.laplace_qtf(q,a,b), [0, 1])
        print("demo_laplace_isf")
        if useplot: plot(lambda q: mpm.laplace_qtf(q,a,b,False), [0, 1])
        return


    # 5.1.40 Logistic distribution, pdf
    def demo_logistic_pdf(ctx):
        print("demo_logistic_pdf")
        a=1; b=2
        if useplot: plot(lambda x: mpm.logistic_pdf(x,a,b), [-10, 10])
        return


    # 5.1.41 Logistic distribution, cdf and sf
    def demo_logistic_cdf(ctx):
        print("demo_logistic_cdf")
        a=1; b=2
        if useplot: plot(lambda x: mpm.logistic_cdf(x,a,b), [-10, 10])
        print("demo_logistic_cdf")
        if useplot: plot(lambda x: mpm.logistic_cdf(x,a,b,False), [-10, 10])
        return


    # 5.1.42 Logistic distribution, qtf and isf
    def demo_logistic_qtf(ctx):
        print("demo_logistic_qtf")
        a=1; b=2
        if useplot: plot(lambda x: mpm.logistic_qtf(x,a,b), [0, 1])
        print("demo_logistic_isf")
        if useplot: plot(lambda x: mpm.logistic_qtf(x,a,b,False), [0, 1])
        return


    # 5.1.43 Lomax distribution, pdf
    def demo_lomax_pdf(ctx):
        print("demo_lomax_pdf")
        a=1; b=2
        if useplot: plot(lambda x: mpm.lomax_pdf(x,a,b), [0, 10])
        return


    # 5.1.44 Lomax distribution, cdf and sf
    def demo_lomax_cdf(ctx):
        print("demo_lomax_cdf")
        a=1; b=2
        if useplot: plot(lambda x: mpm.lomax_cdf(x,a,b), [0, 10])
        print("demo_lomax_sf")
        if useplot: plot(lambda x: mpm.lomax_cdf(x,a,b,False), [0, 10])
        return


    # 5.1.45 Lomax distribution, qtf and isf
    def demo_lomax_qtf(ctx):
        print("demo_lomax_qtf")
        a=1; b=2
        if useplot: plot(lambda q: mpm.lomax_qtf(q,a,b), [0, 1-0.1])
        print("demo_lomax_isf")
        if useplot: plot(lambda q: mpm.lomax_qtf(q,a,b,False), [0.1, 1])
        return


    # 5.1.46 Pareto distribution, pdf
    def demo_pareto_pdf(ctx):
        print("demo_pareto_pdf")
        k=1; a=2
        if useplot: plot(lambda x: mpm.pareto_pdf(x,k,a), [0, 4])
        return


    # 5.1.47 Pareto distribution, cdf and sf
    def demo_pareto_cdf(ctx):
        print("demo_pareto_cdf")
        k=1; a=2
        if useplot: plot(lambda x: mpm.pareto_cdf(x,k,a), [0, 4])
        print("demo_pareto_sf")
        k=1; a=2
        if useplot: plot(lambda x: mpm.pareto_cdf(x,k,a,False), [0, 4])
        return


    # 5.1.48 Pareto distribution, qtf and isf
    def demo_pareto_qtf(ctx):
        print("demo_pareto_qtf")
        k=1; a=2
        if useplot: plot(lambda x: mpm.pareto_qtf(x,k,a), [0, 1])
        print("demo_pareto_sf")
        k=1; a=2
        if useplot: plot(lambda x: mpm.pareto_qtf(x,k,a,False), [0, 1])
        return


    # 5.1.49 Rayleigh distribution, pdf
    def demo_rayleigh_pdf(ctx):
        print("demo_rayleigh_pdf")
        b=2
        if useplot: plot(lambda x: mpm.rayleigh_pdf(x,b), [0, 8])
        return


    # 5.1.50 Rayleigh distribution, cdf and sf
    def demo_rayleigh_cdf(ctx):
        print("demo_rayleigh_cdf")
        b=2
        if useplot: plot(lambda x: mpm.rayleigh_cdf(x,b), [0, 8])
        print("demo_rayleigh_sf")
        if useplot: plot(lambda x: mpm.rayleigh_cdf(x,b,False), [0, 8])
        return


    # 5.1.51 Rayleigh distribution, qtf and isf
    def demo_rayleigh_qtf(ctx):
        print("demo_rayleigh_qtf")
        b=2
        if useplot: plot(lambda q: mpm.rayleigh_qtf(q,b), [0, 1])
        print("demo_rayleigh_sf")
        if useplot: plot(lambda q: mpm.rayleigh_qtf(q,b,False), [0, 1])
        return


    demo_laplace_pdf(ctx)
    demo_laplace_cdf(ctx)
    demo_laplace_qtf(ctx)

    demo_logistic_pdf(ctx)
    demo_logistic_cdf(ctx)
    demo_logistic_qtf(ctx)

    demo_lomax_pdf(ctx)
    demo_lomax_cdf(ctx)
    demo_lomax_qtf(ctx)

    demo_pareto_pdf(ctx)
    demo_pareto_cdf(ctx)
    demo_pareto_qtf(ctx)

    demo_rayleigh_pdf(ctx)
    demo_rayleigh_cdf(ctx)
    demo_rayleigh_qtf(ctx)


    return


def demo_5_1_part4_closed_form_elementary(ctx):



    # 5.1.52 Shifted Gompertz distribution, pdf
    def demo_shifted_gompertz_pdf(ctx):
        print("demo_shifted_gompertz_pdf")
        a=1; b=2
        if useplot: plot(lambda x: mpm.shifted_gompertz_pdf(x,a,b), [0, 4])
        return


    # 5.1.53 Shifted Gompertz distribution, cdf and sf
    def demo_shifted_gompertz_cdf(ctx):
        print("demo_shifted_gompertz_cdf")
        a=1; b=2
        if useplot: plot(lambda x: mpm.shifted_gompertz_cdf(x,a,b), [0, 4])
        print("demo_shifted_gompertz_cdf")
        a=1; b=2
        if useplot: plot(lambda x: mpm.shifted_gompertz_cdf(x,a,b,False), [0, 4])
        return


    # 5.1.54 Shifted Gompertz distribution, qtf and isf
    def demo_shifted_gompertz_qtf(ctx):
        print("demo_shifted_gompertz_qtf")
        a=1; b=2
        if useplot: plot(lambda q: mpm.shifted_gompertz_qtf(q,a,b), [0, 1])
        print("demo_shifted_gompertz_sf")
        if useplot: plot(lambda q: mpm.shifted_gompertz_qtf(q,a,b,False), [0, 1])
        return


    # 5.1.55 Singh-Maddala (Burr Type XII) distribution, pdf
    def demo_singh_maddala_pdf(ctx):
        print("demo_singh_maddala_pdf")
        a=1; b=2; d=3
        if useplot: plot(lambda x: mpm.singh_maddala_pdf(x,a,b,d), [0, 4])
        return


    # 5.1.56 Singh-Maddala (Burr Type XII) distribution, cdf and sf
    def demo_singh_maddala_cdf(ctx):
        print("demo_singh_maddala_cdf")
        a=1; b=2; d=3
        if useplot: plot(lambda x: mpm.singh_maddala_cdf(x,a,b,d), [0, 4])
        print("demo_singh_maddala_cdf")
        if useplot: plot(lambda x: mpm.singh_maddala_cdf(x,a,b,d,False), [0, 4])
        return


    # 5.1.57 Singh-Maddala (Burr Type XII) distribution, qtf and isf
    def demo_singh_maddala_qtf(ctx):
        print("demo_singh_maddala_qtf")
        a=1; b=2; d=3
        if useplot: plot(lambda x: mpm.singh_maddala_qtf(x,a,b,d), [0, 1])
        print("demo_singh_maddala_cdf")
        if useplot: plot(lambda x: mpm.singh_maddala_qtf(x,a,b,d,False), [0, 1])
        return


    # 5.1.58 Triangular distribution, pdf
    def demo_triangular_pdf(ctx):
        print("demo_triangular_pdf")
        a=1; b=7; c=3
        if useplot: plot(lambda x: mpm.triangular_pdf(x,a,b,c), [0, 8])
        return


    # 5.1.59 Triangular distribution, cdf and sf
    def demo_triangular_cdf(ctx):
        print("demo_triangular_cdf")
        a=1; b=7; c=3
        if useplot: plot(lambda x: mpm.triangular_cdf(x,a,b,c), [0, 8])
        print("demo_triangular_sf")
        if useplot: plot(lambda x: mpm.triangular_cdf(x,a,b,c,False), [0, 8])
        return


    # 5.1.60 Triangular distribution, qtf and isf
    def demo_triangular_qtf(ctx):
        print("demo_triangular_qtf")
        a=1; b=7; c=3
        if useplot: plot(lambda q: mpm.triangular_qtf(q,a,b,c), [0, 1])
        print("demo_triangular_sf")
        if useplot: plot(lambda q: mpm.triangular_qtf(q,a,b,c,False), [0, 1])
        return


    # 5.1.61 Uniform distribution, pdf
    def demo_uniform_pdf(ctx):
        print("demo_uniform_pdf")
        a=1; b=7
        if useplot: plot(lambda x: mpm.uniform_pdf(x,a,b), [0, 8])
        return


    # 5.1.62 Uniform distribution, cdf and sf
    def demo_uniform_cdf(ctx):
        print("demo_uniform_cdf")
        a=1; b=7
        if useplot: plot(lambda x: mpm.uniform_cdf(x,a,b), [0, 8])
        print("demo_uniform_sf")
        if useplot: plot(lambda x: mpm.uniform_cdf(x,a,b,False), [0, 8])
        return


    # 5.1.63 Uniform distribution, qtf and isf
    def demo_uniform_qtf(ctx):
        print("demo_uniform_qtf")
        a=1; b=7
        if useplot: plot(lambda q: mpm.uniform_qtf(q,a,b), [0, 1])
        print("demo_uniform_sf")
        if useplot: plot(lambda q: mpm.uniform_qtf(q,a,b,False), [0, 1])
        return


    # 5.1.64 Weibull distribution, pdf
    def demo_weibull_pdf(ctx):
        print("demo_weibull_pdf")
        a=2; b=3
        if useplot: plot(lambda x: mpm.weibull_pdf(x,a,b), [0, 8])
        return


    # 5.1.65 Weibull distribution, cdf and sf
    def demo_weibull_cdf(ctx):
        print("demo_weibull_cdf")
        a=2; b=3
        if useplot: plot(lambda x: mpm.weibull_cdf(x,a,b), [0, 8])
        print("demo_weibull_sf")
        a=2; b=3
        if useplot: plot(lambda x: mpm.weibull_cdf(x,a,b,False), [0, 8])
        return


    # 5.1.66 Weibull distribution, qtf and isf
    def demo_weibull_qtf(ctx):
        print("demo_weibull_qtf")
        a=2; b=3
        if useplot: plot(lambda x: mpm.weibull_qtf(x,a,b), [0, 1])
        print("demo_weibull_sf")
        a=2; b=3
        if useplot: plot(lambda x: mpm.weibull_qtf(x,a,b,False), [0, 1])
        return


    demo_shifted_gompertz_pdf(ctx)
    demo_shifted_gompertz_cdf(ctx)
    demo_shifted_gompertz_qtf(ctx)

    demo_singh_maddala_pdf(ctx)
    demo_singh_maddala_cdf(ctx)
    demo_singh_maddala_qtf(ctx)

    demo_triangular_pdf(ctx)
    demo_triangular_cdf(ctx)
    demo_triangular_qtf(ctx)

    demo_uniform_pdf(ctx)
    demo_uniform_cdf(ctx)
    demo_uniform_qtf(ctx)

    demo_weibull_pdf(ctx)
    demo_weibull_cdf(ctx)
    demo_weibull_qtf(ctx)


    return




#  5.2 Closed form distributions, based on the error function

def demo_5_2_part1_closed_form_error_function(ctx):



    # 5.2.1 Birnbaum-Saunders distribution, pdf
    def demo_birnb_saunders_pdf(ctx):
        print("birnb_saunders_pdf")
        return

    # 5.2.2 Birnbaum-Saunders distribution, cdf and sf
    def demo_birnb_saunders_cdf(ctx):
        print("birnb_saunders_cdf")
        return

    # 5.2.3 Birnbaum-Saunders distribution distribution, qtf and isf
    def demo_birnb_saunders_qtf(ctx):
        print("birnb_saunders_qtf")
        return


    # 5.2.4 Exponentially Modified Gaussian (EMG) distribution, pdf
    def demo_emg_pdf(ctx):
        print("emg_pdf")
        return

    # 5.2.5 Exponentially Modified Gaussian (EMG) distribution, cdf and sf
    def demo_emg_cdf(ctx):
        print("emg_cdf")
        return

    # 5.2.6 Exponentially Modified Gaussian (EMG) distribution, qtf and isf
    def demo_emg_qtf(ctx):
        print("emg_qtf")
        return


    # 5.2.7 Folded normal distribution, pdf
    def demo_folded_normal_pdf(ctx):
        print("folded_normal_pdf")
        return

    # 5.2.8 Folded normal distribution, cdf and sf
    def demo_folded_normal_cdf(ctx):
        print("folded_normal_cdf")
        return

    # 5.2.9 Folded normal distribution, qtf and isf
    def demo_folded_normal_qtf(ctx):
        print("folded_normal_qtf")
        return


    # 5.2.10 Half-normal distribution, pdf
    def demo_half_normal_pdf(ctx):
        print("half_normal_pdf")
        return

    # 5.2.11 Half_normal distribution, cdf and sf
    def demo_half_normal_cdf(ctx):
        print("half_normal_cdf")
        return

    # 5.2.12 Half_normal distribution, qtf and isf
    def demo_half_normal_qtf(ctx):
        print("half_normal_qtf")
        return


    # 5.2.13 Johnson 𝑆𝐵 distribution, pdf
    def demo_johnson_sb_pdf(ctx):
        print("johnson_sb_pdf")
        return

    # 5.2.14 Johnson 𝑆𝐵 distribution, cdf and sf
    def demo_johnson_sb_cdf(ctx):
        print("johnson_sb_cdf")
        return

    # 5.2.15 Johnson 𝑆𝐵 distribution, qtf and isf
    def demo_johnson_sb_qtf(ctx):
        print("johnson_sb_qtf")
        return


    # 5.2.16 Johnson 𝑆𝑈 distribution, pdf
    def demo_johnson_su_pdf(ctx):
        print("johnson_su_pdf")
        return

    # 5.2.17 Johnson 𝑆𝑈 distribution, cdf and sf
    def demo_johnson_su_cdf(ctx):
        print("johnson_su_cdf")
        return

    # 5.2.18 Johnson 𝑆𝑈 distribution, qtf and isf
    def demo_johnson_su_qtf(ctx):
        print("johnson_su_qtf")
        return


    demo_birnb_saunders_pdf(ctx)
    demo_birnb_saunders_cdf(ctx)
    demo_birnb_saunders_qtf(ctx)

    demo_emg_pdf(ctx)
    demo_emg_cdf(ctx)
    demo_emg_qtf(ctx)

    demo_folded_normal_pdf(ctx)
    demo_folded_normal_cdf(ctx)
    demo_folded_normal_qtf(ctx)

    demo_half_normal_pdf(ctx)
    demo_half_normal_cdf(ctx)
    demo_half_normal_qtf(ctx)

    demo_johnson_sb_pdf(ctx)
    demo_johnson_sb_cdf(ctx)
    demo_johnson_sb_qtf(ctx)

    demo_johnson_su_pdf(ctx)
    demo_johnson_su_cdf(ctx)
    demo_johnson_su_qtf(ctx)


    return


def demo_5_2_part2_closed_form_error_function(ctx):




    # 5.2.19 Lévy distribution, pdf
    def demo_levy_pdf(ctx):
        print("levy_pdf")
        return

    # 5.2.20 Lévy distribution, cdf and sf
    def demo_levy_cdf(ctx):
        print("levy_cdf")
        return

    # 5.2.21 Lévy distribution, qtf and isf
    def demo_levy_qtf(ctx):
        print("levy_qtf")
        return


    # 5.2.22 Lognormal distribution, pdf
    def demo_lognormal_pdf(ctx):
        print("lognormal_pdf")
        return

    # 5.2.23 Lognormal distribution, cdf and sf
    def demo_lognormal_cdf(ctx):
        print("lognormal_cdf")
        return

    # 5.2.24 Lognormal distribution, qtf and isf
    def demo_lognormal_qtf(ctx):
        print("lognormal_qtf")
        return


    # 5.2.25 Moyal distribution, pdf
    def demo_moyal_pdf(ctx):
        print("moyal_pdf")
        return

    # 5.2.26 Moyal distribution, cdf and sf
    def demo_moyal_cdf(ctx):
        print("moyal_cdf")
        return

    # 5.2.27 Moyal distribution, qtf and isf
    def demo_moyal_qtf(ctx):
        print("moyal_qtf")
        return


    # 5.2.28 Normal (Johnson SN) distribution, pdf
    def demo_normal_pdf(ctx):
        print("demo_arcsine_pdf")
        return

    # 5.2.29 Normal (Johnson SN) distribution, cdf and sf
    def demo_normal_cdf(ctx):
        print("normal_cdf")
        return

    # 5.2.30 Normal (Johnson SN) distribution, qtf and isf
    def demo_normal_qtf(ctx):
        print("normal_qtf")
        return



    # 5.2.31 Normal maximum distribution: pdf

    def temp1(self, z):
        res =mpm.sign(z) * mpm.log10(1+mpm.fabs(z))
        #res =mpm.log10(1+mpm.fabs(z))
        return res


    def demo_nmax_0_pdf(ctx):
        mpm.dps = 5
        print("demo_nmax_0_pdf():")
    #        k = 4
    #        x = 2.234
        k = 10
        x = 2.234
        res = mpm.nmax_pdf(x, k)
        print(res)
    #        res = mpm.diff(lambda x:  mpm.nmax_cdf(x, k), x)
    #        print(res)
    #        plot(lambda x: mpm.nmax_pdf(x, k), [-3, 5])
    #        plot(lambda x:  mpm.diff(lambda x: mpm.nmax_pdf(x, k), x), [-3, 5])
    #        plot(lambda x:  mpm.diff(lambda x: mpm.nmax_pdf(x, k), x, 2), [-3, 5])
    #        plot(lambda x:  mpm.diff(lambda x: mpm.nmax_pdf(x, k), x, 3), [-3, 5])
    #        plot(lambda x:  mpm.diff(lambda x: mpm.nmax_pdf(x, k), x, 4), [-3, 5])
        n = 10
    #        plot(lambda x:  mpm.diff(lambda x: mpm.nmax_pdf(x, k), x, n), [-3, 5])
        plot(lambda x:  temp1(mpm.diff(lambda x: mpm.nmax_pdf(x, k), x, n)), [-10, 10])
        #plot(lambda x:  mpm.diff(lambda x: mpm.exp(x)* mpm.nmax_pdf(x, k), x, 30), [15, 20])
        E1 = 2**(2*n+1)*(mpm.factorial(n))**4
        E2 = (2*n+1)*(mpm.factorial(2*n))**3
        E = E1/E2
        print("k:", k, "n:", n, ", E:", E)
        return

    #mpm.plot(lambda y: mpm.diff(lambda y: mpm.exp(1*y/2)*mpm.ndis(-x*mpm.sqrt(y/n)-delta)*mpm.chi2_pdf(y, n), y, 5),[200,350])


    def demo_nmax_0_pdf2(ctx):
        mpm.dps = 15
        print("demo_nmax_0_pdf2():")
        n = 66
        x = 10
        delta = 0
        k=25
        def f(y):
            res = mpm.exp(1*y/2)*mpm.ndis(-x*mpm.sqrt(y/n)-delta)*mpm.chi2_pdf(y, n)
    #            res = mpm.ndis(-x*mpm.sqrt(y/n)-delta)*mpm.chi2_pdf(y, n)
            return res
        if useplot: mpm.plot(lambda y: mpm.diff(lambda y: f(y), y, k),[00,30])
        print("n:",n,"k:",k)
        E1 = (mpm.factorial(k))**2
        E2 = (mpm.factorial(2*k))
        E = E1/E2
        print("E:", E)
        return

    # 5.2.32 Normal maximum distribution: cdf and sf

    def demo_nmax_0_cdf(ctx):
        print("demo_nmax_0_cdf():")
        k = 4
        x = 2.234
        res = mpm.nmax_cdf(x, k)
        print(res)
        return

    # 5.2.33 Normal maximum distribution qtf and isf

    def demo_nmax_0_qtf(ctx):
        print("demo_nmax_0_qtf():")
        return

    # 5.2.34 Normal maximum modulus distribution = 0: pdf

    def demo_nmm_0_pdf(ctx):
        print("demo_nmm_0_pdf():")
        k = 4
        x = 3.022
        res = mpm.nmm_pdf(x, k)
        print(res)
        res = mpm.diff(lambda x: mpm.nmm_cdf(x, k), x)
        print(res)
        return

    # 5.2.35 Normal maximum modulus distribution: cdf and sf

    def demo_nmm_0_cdf(ctx):
        print("demo_nmm_0_cdf():")
        k = 4
        x = 3.022
        res = mpm.nmm_cdf(x, k)
        print(res)
        return

    # 5.2.36 Normal maximum modulus distribution: qtf and isf

    def demo_nmm_0_qtf(ctx):
        print("demo_nmm_0_qtf():")
        return



    demo_levy_pdf(ctx)
    demo_levy_cdf(ctx)
    demo_levy_qtf(ctx)

    demo_lognormal_pdf(ctx)
    demo_lognormal_cdf(ctx)
    demo_lognormal_qtf(ctx)

    demo_moyal_pdf(ctx)
    demo_moyal_cdf(ctx)
    demo_moyal_qtf(ctx)

    demo_normal_pdf(ctx)
    demo_normal_cdf(ctx)
    demo_normal_qtf(ctx)

    demo_nmax_0_pdf2(ctx)
    demo_nmax_0_cdf(ctx)
    demo_nmax_0_qtf(ctx)

    demo_nmm_0_pdf(ctx)
    demo_nmm_0_cdf(ctx)
    demo_nmm_0_qtf(ctx)



    return


def demo_5_2_part3_closed_form_error_function(ctx):


    # 5.2.37 Sinh-arcsinh normal distribution, pdf
    def demo_sasnormal_pdf(ctx):
        print("sasdemo_arcsine_pdf")
        return

    # 5.2.38 Sinh-arcsinh normal distribution, cdf and sf
    def demo_sasnormal_cdf(ctx):
        print("sasnormal_cdf")
        return

    # 5.2.39 Sinh-arcsinh normal distribution, qtf and isf
    def demo_sasnormal_qtf(ctx):
        print("sasnormal_qtf")
        return


    # 5.2.40 Skew normal distribution, pdf
    def demo_skewnormal_pdf(ctx):
        print("skewnormal_pdf")
        return

    # 5.2.41 Skew normal distribution, cdf and sf
    def demo_skewnormal_cdf(ctx):
        print("skewnormal_cdf")
        return

    # 5.2.42 Skew normal distribution, qtf and isf
    def demo_skewnormal_qtf(ctx):
        print("skewnormal_qtf")
        return


    # 5.2.43 Truncated normal distribution, pdf
    def demo_trunc_normal_pdf(ctx):
        print("trunc_normal_pdf")
        return

    # 5.2.44 Truncated normal distribution, cdf and sf
    def demo_trunc_normal_cdf(ctx):
        print("trunc_normal_cdf")
        return

    # 5.2.45 Truncated normal distribution, qtf and isf
    def demo_trunc_normal_qtf(ctx):
        print("trunc_normal_qtf")
        return


    # 5.2.46 Wald distribution, pdf
    def demo_wald_pdf(ctx):
        print("wald_pdf")
        return

    # 5.2.47 Wald distribution, cdf and sf
    def demo_wald_cdf(ctx):
        print("wald_cdf")
        return

    # 5.2.48 Wald distribution, qtf and isf
    def demo_wald_qtf(ctx):
        print("wald_qtf")
        return


    demo_sasnormal_pdf(ctx)
    demo_sasnormal_cdf(ctx)
    demo_sasnormal_qtf(ctx)

    demo_skewnormal_pdf(ctx)
    demo_skewnormal_cdf(ctx)
    demo_skewnormal_qtf(ctx)

    demo_trunc_normal_pdf(ctx)
    demo_trunc_normal_cdf(ctx)
    demo_trunc_normal_qtf(ctx)

    demo_wald_pdf(ctx)
    demo_wald_cdf(ctx)
    demo_wald_qtf(ctx)
    return




# 5.3 Closed form distributions, based on the incomplete gamma function

def demo_5_3_part1_closed_form_incomplete_gamma_function(ctx):

    # 5.3.1 Amoroso distribution, pdf
    def demo_amoroso_pdf(ctx):
        print("demo_amoroso_pdf")
        return

    # 5.3.2 Amoroso distribution, cdf and sf
    def demo_amoroso_cdf(ctx):
        print("demo_amoroso_cdf")
        return

    # 5.3.3 Amoroso distribution, qtf and isf
    def demo_amoroso_qtf(ctx):
        print("demo_amoroso_qtf")
        return


    # 5.3.4 𝜒-distribution, pdf
    def demo_chi_pdf(ctx):
        print("demo_chi_pdf")
        return

    # 5.3.5 𝜒-distribution, cdf and sf
    def demo_chi_cdf(ctx):
        print("demo_chi_cdf")
        return

    # 5.3.6 𝜒-distribution, qtf and isf
    def demo_chi_qtf(ctx):
        print("demo_chi_qtf")
        return


    # 5.3.7 𝜒2-distribution, pdf
    def demo_chi2_pdf(ctx):
        print("demo_chi2_pdf")
        return

    # 5.3.8 𝜒2-distribution, cdf and sf
    def demo_chi2_cdf(ctx):
        print("demo_chi2_cdf")
        return

    # 5.3.9 𝜒2-distribution, qtf and isf
    def demo_chi2_qtf(ctx):
        print("demo_chi2_qtf")
        return


    # 5.3.10 Distribution of the logarithm of a 𝜒2 random variable, pdf
    def demo_logchisquare_pdf(ctx):
        print("demo_logchisquare_pdf")
        return

    # 5.3.11 Distribution of the logarithm of a 𝜒2 random variable, cdf and sf
    def demo_logchisquare_cdf(ctx):
        print("demo_logchisquare_cdf")
        return

    def demo_logchisquare_sf(ctx):
        print("demo_logchisquare_sf")
        return

    # 5.3.12 Distribution of the logarithm of a 𝜒2 random variable, qtf and isf
    def demo_logchisquare_qtf(ctx):
        print("demo_logchisquare_qtf")
        return

    def demo_logchisquare_isf(ctx):
        print("demo_logchisquare_isf")
        return


    def demo_logchisquare_pdf2(ctx):
        n = 1.5
        x = 3
        n = 10
        res = mpm.logchisquare_pdf(x, n)
        print("pdf: ", res)
        res = mpm.logchisquare_cdf(x, n)
        print("cdf: ", res)
        res = mpm.logchisquare_sf(x, n)
        print("sf : ", res)
        print()
        return

    #    plot(lambda x: logchisquare_pdf(x, n), [-1, 6])
    #    plot(lambda x: logchisquare_cdf(x, n), [-1, 6])


    demo_amoroso_pdf(ctx)
    demo_amoroso_cdf(ctx)
    demo_amoroso_qtf(ctx)

    demo_chi_pdf(ctx)
    demo_chi_cdf(ctx)
    demo_chi_qtf(ctx)

    demo_chi2_pdf(ctx)
    demo_chi2_cdf(ctx)
    demo_chi2_qtf(ctx)

    demo_logchisquare_pdf(ctx)
    demo_logchisquare_cdf(ctx)
    demo_logchisquare_sf(ctx)
    demo_logchisquare_qtf(ctx)
    demo_logchisquare_isf(ctx)
    demo_logchisquare_pdf2(ctx)


    return


def demo_5_3_part2_closed_form_incomplete_gamma_function(ctx):

    # 5.3.13 Gamma distribution, pdf
    def demo_gamma_pdf(ctx):
        print("demo_gamma_pdf")
        return

    # 5.3.14 Gamma distribution, cdf and sf
    def demo_gamma_cdf(ctx):
        print("demo_gamma_cdf")
        return

    # 5.3.15 Gamma distribution, qtf and isf
    def demo_gamma_qtf(ctx):
        print("demo_gamma_qtf")
        return


    # 5.1.16 Hypoexponential distribution, pdf
    def demo_hypoexp_pdf(ctx):
        print("demo_hypoexp_pdf")
        return


    # 5.1.17 Hypoexponential distribution, cdf and sf
    def demo_hypoexp_cdf(ctx):
        print("demo_hypoexp_cdf")
        x = 1.5
        n = 4

    #        l = [1,2,3,4]
    #        AllDistinct=True
    #        AllEqual=False

        l = [2,2,2,2]
        AllDistinct=False
        AllEqual=True

        if AllEqual:
            pdf = l[0]**n * x**(n-1)*mpm.exp(-l[0]*x)/mpm.factorial(n-1)
            print("pdf:", pdf)
            cdf = mpm.gamma_p(n, l[0]*x)
            print("cdf:", cdf)
            sf = mpm.gamma_q(n, l[0]*x)
            print(" sf:", sf)

        if AllDistinct:
            p = [1, 1, 1, 1]
            for i in range(n):
                for j in range(n):
                    if i!= j:
                        p[i] = p[i] * (1-l[i]/l[j])
            psum = 0
            for j in range(n):
                psum += 1/p[j]
            print("psum:", psum)
            pdf = 0
            for i in range(n):
                pdf += l[i] * mpm.exp(-l[i]*x) / p[i]
            print("pdf:", pdf)
            sf = 0
            for i in range(n):
                sf += mpm.exp(-l[i]*x) / p[i]
            cdf = 1-sf
            print("cdf:", cdf)
            print(" sf:", sf)
            print()



        a = mpm.matrix([1,0,0,0])
        one = mpm.matrix([1,1,1,1])
        Theta = mpm.matrix(4,4)
    #        print(Theta)
        Theta[0,0] = -l[0]
        Theta[0,1] = l[0]
        Theta[1,1] = -l[1]
        Theta[1,2] = l[1]
        Theta[2,2] = -l[2]
        Theta[2,3] = l[2]
        Theta[3,3] = -l[3]
    #        print(Theta)
    #        print()

        xt = x*Theta
        expxt = mpm.expm(xt)
        expxt = mpm.expm(xt)
    #        print(expxt)
    #        print()

        aexpxt = a.T*expxt
    #        print(aexpxt)
    #        print()
        aexpxtt = -aexpxt *Theta*one
        print("pdf:", aexpxtt)

        oaexpxt = aexpxt*one
        print("cdf:", 1-oaexpxt)
        print(" sf:", oaexpxt)
    #        print()
        print()
        return


    # 5.1.18 Hypoexponential distribution, qtf and isf
    def demo_hypoexp_qtf(ctx):
        return


    # 5.3.19 Inverse chi2-distribution, pdf
    def demo_invchisquared_pdf(ctx):
        print("demo_invchisquared_pdf")
        return

    # 5.3.20 Inverse chi2-distribution, cdf and sf
    def demo_invchisquared_cdf(ctx):
        print("demo_invchisquared_cdf")
        return

    # 5.3.21 Inverse chi2-distribution, qtf and isf
    def demo_invchisquared_qtf(ctx):
        print("demo_invchisquared_qtf")
        return


    # 5.3.22 Inverse Gamma distribution, pdf
    def demo_invgamma_pdf(ctx):
        print("demo_invgamma_pdf")
        return

    # 5.3.23 Inverse Gamma distribution, cdf and sf
    def demo_invgamma_cdf(ctx):
        print("demo_invgamma_cdf")
        return

    # 5.3.24 Inverse Gamma distribution, qtf and isf
    def demo_invgamma_qtf(selfs):
        print("demo_invgamma_qtf")
        return


    # 5.3.25 Maxwell distribution, pdf
    def demo_maxwell_pdf(ctx):
        print("demo_maxwell_pdf")
        return

    # 5.3.26 Maxwell distribution, cdf and sf
    def demo_maxwell_cdf(ctx):
        print("demo_maxwell_cdf")
        return

    # 5.3.27 Maxwell distribution, qtf and isf
    def demo_maxwell_qtf(ctx):
        print("demo_maxwell_qtf")
        return



    demo_gamma_pdf(ctx)
    demo_gamma_cdf(ctx)
    demo_gamma_qtf(ctx)

    demo_hypoexp_pdf(ctx)
    demo_hypoexp_cdf(ctx)
    demo_hypoexp_qtf(ctx)

    demo_invchisquared_pdf(ctx)
    demo_invchisquared_cdf(ctx)
    demo_invchisquared_qtf(ctx)

    demo_invgamma_pdf(ctx)
    demo_invgamma_cdf(ctx)
    demo_invgamma_qtf(ctx)

    demo_maxwell_pdf(ctx)
    demo_maxwell_cdf(ctx)
    demo_maxwell_qtf(ctx)




    return


def demo_5_3_part3_closed_form_incomplete_gamma_function(ctx):



    # 5.3.28 Lindley distribution (generalized), pdf
    def demo_lindley_pdf(ctx):
        print("demo_lindley_pdf")
        return

    # 5.3.29 Lindley distribution (generalized), cdf and sf
    def demo_lindley_cdf(ctx):
        print("demo_lindley_cdf")
        return

    # 5.3.30 Lindley distribution (generalized), qtf and isf
    def demo_lindley_qtf(ctx):
        print("demo_lindley_qtf")
        return


    # 5.3.31 Nakagami distribution, pdf
    def demo_nakagami_pdf(ctx):
        print("demo_nakagami_pdf")
        return

    # 5.3.32 Nakagami distribution, cdf and sf
    def demo_nakagami_cdf(ctx):
        print("demo_nakagami_cdf")
        return

    # 5.3.33 Nakagami distribution, qtf and isf
    def demo_nakagami_qtf(ctx):
        print("demo_nakagami_qtf")
        return


    # 5.3.34 Skew exponential power distribution, pdf
    def demo_skew_exp_power_pdf(ctx):
        print("demo_skew_exp_power_pdf")
        return

    # 5.3.35 Skew exponential power distribution, cdf and sf
    def demo_skew_exp_power_cdf(ctx):
        print("demo_skew_exp_power_cdf")
        return

    # 5.3.36 Skew exponential power distribution, qtf and isf
    def demo_skew_exp_power_qtf(ctx):
        print("demo_skew_exp_power_qtf")
        return


    # 5.3.37 Stacy (generalized gamma) distribution, pdf
    def demo_stacy_pdf(ctx):
        print("demo_stacy_pdf")
        return

    # 5.3.38 Stacy (generalized gamma) distribution, cdf and sf
    def demo_stacy_cdf(ctx):
        print("demo_stacy_cdf")
        return

    # 5.3.39 Stacy (generalized gamma) distribution, qtf and isf
    def demo_stacy_qtf(ctx):
        print("demo_stacy_qtf")
        return

    demo_lindley_pdf(ctx)
    demo_lindley_cdf(ctx)
    demo_lindley_qtf(ctx)

    demo_nakagami_pdf(ctx)
    demo_nakagami_cdf(ctx)
    demo_nakagami_qtf(ctx)

    demo_skew_exp_power_pdf(ctx)
    demo_skew_exp_power_cdf(ctx)
    demo_skew_exp_power_qtf(ctx)

    demo_stacy_pdf(ctx)
    demo_stacy_cdf(ctx)
    demo_stacy_qtf(ctx)

    return







# 5.4 Main Closed form distributions, based on the incomplete beta function

def demo_5_4_part1_closed_form_incomplete_beta_function(ctx):

    # 5.4.1 Beta distribution, pdf
    def demo_beta_pdf(ctx):
        print("demo_beta_pdf")
        return

    # 5.4.2 Beta distribution, cdf and sf
    def demo_beta_cdf(ctx):
        print("demo_beta_cdf")
        return

    # 5.4.3 Beta distribution, qtf and isf
    def demo_beta_qtf(ctx):
        print("demo_beta_qtf")
        return


    # 5.4.4 Distribution of the negative logarithm of a beta variable, pdf
    def demo_logrv_beta_pdf(ctx):
        a = 10
        b = 20
    #    plot(lambda x: logbeta_pdf(x, a, b), [0, 3])
    #    plot(lambda x: logbeta_cdf(x, a, b), [0, 3])
    #    plot(lambda x: logbeta_sf(x, a, b), [0, 3])

        x = 1.25

        qres = mpm.logrv_beta_cdf(x, a, b)
        print("qres:", qres)

        xres = mpm.logrv_beta_qtf(qres, a, b)
        print("xres:", xres)

        qres = mpm.logrv_beta_sf(x, a, b)
        print("qres:", qres)

        xres = mpm.logrv_beta_isf(qres, a, b)
        print("xres:", xres)

        xres = mpm.logrv_beta_qtf(1-qres, a, b)
        print("xres:", xres)


    # 5.4.5 Distribution of the negative logarithm of a beta variable, cdf and sf
    def demo_logrv_beta_cdf(ctx):
        print("demo_logrv_beta_cdf")
        return

    def demo_logrv_beta_sf(ctx):
        print("demo_logrv_beta_sf")
        return


    # 5.4.6 Distribution of the negative logarithm of a beta variable, qtf and isf
    def demo_logrv_beta_qtf(ctx):
        print("demo_logrv_beta_qtf")
        return

    def demo_logrv_beta_isf(ctx):
        print("demo_logrv_beta_isf")
        return


    # 5.4.7 Beta-prime distribution, pdf
    def demo_beta_prime_pdf(ctx):
        print("demo_beta_prime_pdf")
        return

    # 5.4.8 Beta-prime distribution, cdf and sf
    def demo_beta_prime_cdf(ctx):
        print("demo_beta_prime_cdf")
        return

    # 5.4.9 Beta-prime distribution, qtf and isf
    def demo_beta_prime_qtf(ctx):
        print("demo_beta_prime_qtf")
        return


    demo_beta_pdf(ctx)
    demo_beta_cdf(ctx)
    demo_beta_qtf(ctx)

    demo_logrv_beta_pdf(ctx)
    demo_logrv_beta_cdf(ctx)
    demo_logrv_beta_sf(ctx)
    demo_logrv_beta_qtf(ctx)
    demo_logrv_beta_isf(ctx)

    demo_beta_prime_pdf(ctx)
    demo_beta_prime_cdf(ctx)
    demo_beta_prime_qtf(ctx)


    return


def demo_5_4_part2_closed_form_incomplete_beta_function(ctx):



    # 5.4.10 Generalized Beta (Type 1) distribution, pdf
    def demo_genbeta1_pdf(ctx):
        print("demo_genbeta1_pdf")
        return

    # 5.4.11 Generalized Beta (Type 1) distribution, cdf and sf
    def demo_genbeta1_cdf(ctx):
        print("demo_genbeta1_cdf")
        return

    # 5.4.12 Generalized Beta (Type 1) distribution, qtf and isf
    def demo_genbeta1_qtf(ctx):
        print("demo_genbeta1_qtf")
        return


    # 5.4.13 Generalized Beta (Type 2) distribution, pdf
    def demo_genbeta2_pdf(ctx):
        print("demo_genbeta2_pdf")
        return

    # 5.4.14 Generalized Beta (Type 2) distribution, cdf and sf
    def demo_genbeta2_cdf(ctx):
        print("demo_genbeta2_cdf")
        return

    # 5.4.15 Generalized Beta (Type 2) distribution, qtf and isf
    def demo_genbeta2_qtf(ctx):
        print("demo_genbeta2_qtf")
        return


    # 5.4.16 Generalized logistic distribution, pdf
    def demo_genlogistic_pdf(ctx):
        print("demo_genlogistic_pdf")
        return

    # 5.4.17 Generalized logistic distribution, cdf and sf
    def demo_genlogistic_cdf(ctx):
        print("demo_genlogistic_cdf")
        return

    # 5.4.18 Generalized logistic distribution, qtf and isf
    def demo_genlogistic_qtf(ctx):
        print("demo_genlogistic_qtf")
        return


    # 5.4.19 Generalized beta-exponential distribution, pdf

    def demo_gen_beta_exp_pdf(ctx):
        print("demo_gen_beta_exp_pdf")
        return

    # 5.4.20 Generalized beta-exponential distribution, cdf and sf
    def demo_gen_beta_exp_cdf(ctx):
        print("demo_gen_beta_exp_cdf")
        return

    # 5.4.21 Generalized beta-exponential distribution, qtf and isf
    def demo_gen_beta_exp_qtf(ctx):
        print("demo_gen_beta_exp_qtf")
        return


    # 5.4.22 Feller-Pareto distribution, pdf
    def demo_feller_pareto_pdf(ctx):
        print("demo_feller_pareto_pdf")
        return

    # 5.4.23 Feller-Pareto distribution, cdf and sf
    def demo_feller_pareto_cdf(ctx):
        print("demo_feller_pareto_cdf")
        return

    # 5.4.24 Feller-Pareto distribution, qtf and isf
    def demo_feller_pareto_qtf(ctx):
        print("demo_feller_pareto_qtf")
        return


    demo_genbeta1_pdf(ctx)
    demo_genbeta1_cdf(ctx)
    demo_genbeta1_qtf(ctx)

    demo_genbeta2_pdf(ctx)
    demo_genbeta2_cdf(ctx)
    demo_genbeta2_qtf(ctx)


    demo_genlogistic_pdf(ctx)
    demo_genlogistic_cdf(ctx)
    demo_genlogistic_qtf(ctx)

    demo_gen_beta_exp_pdf(ctx)
    demo_gen_beta_exp_cdf(ctx)
    demo_gen_beta_exp_qtf(ctx)

    demo_feller_pareto_pdf(ctx)
    demo_feller_pareto_cdf(ctx)
    demo_feller_pareto_qtf(ctx)



    return


def demo_5_4_part3_closed_form_incomplete_beta_function(ctx):


    # 5.4.25 Fisher F distribution, pdf
    def demo_fisher_f_pdf(ctx):
        print("demo_fisher_f_pdf")
        return

    # 5.4.26 Fisher F distribution, cdf and sf
    def demo_fisher_f_cdf(ctx):
        print("demo_fisher_f_cdf")
        return

    # 5.4.27 Fisher F distribution, qtf and isf
    def demo_fisher_f_qtf(ctx):
        print("demo_fisher_f_qtf")
        return


    # 5.4.28 Fisher z distribution, pdf
    def demo_fisher_z_pdf(ctx):
        print("demo_fisher_z_pdf")
        return

    # 5.4.29 Fisher z distribution, cdf and sf
    def demo_fisher_z_cdf(ctx):
        print("demo_fisher_z_cdf")
        return

    def demo_fisher_z_sf(ctx):
        print("demo_fisher_z_sf")
        return

    # 5.4.30 Fisher z distribution, qtf and isf
    def demo_fisher_z_qtf(ctx):
        print("wald_qtf")
        return

    def demo_fisher_z_isf(ctx):
        print("demo_fisher_z_isf")
        return



    def demo_fisher_z(ctx):
        m = 2.0
        n = 11.0
        mode = 0
    #    plot(lambda x: fisher_z_pdf(x, m, n, 0), [-2, 12])
    #    plot(lambda x: fisher_z_pdf(x, m, n, mode), [-1, 14])
    #    plot(lambda x: fisher_z_cdf(x, m, n, 0), [-2, 12])
        #plot(lambda x: mpm.fisher_z_cdf(x, m, n, mode), [-5, 5])
        q = 0.25
        x1 = mpm.fisher_z_qtf(q, m, n, mode)
        print("x1:", x1)
        xres1 = mpm.fisher_z_cdf(x1, m, n, mode)
        print("xres1:", xres1)

        x2 = mpm.fisher_z_isf(q, m, n, mode)
        print("x2:", x2)
        xres2 = mpm.fisher_z_sf(x2, m, n, mode)
        print("xres2:", xres2)

        x = 2.5
        res1 = mpm.fisher_z_cdf(x, m, n, mode)
        print("res1:", res1)
        print("res2:", 1-res1)
        res3 = mpm.fisher_z_sf(x, m, n, mode)
        print("res3:", res3)

    #    plot(lambda q: fisher_z_qtf(q, m, n, 0), [0.001, 0.999])
    #    plot(lambda q: fisher_z_qtf(q, m, n, mode), [0.001, 0.999])






    # 5.4.31 Student t distribution, pdf
    def demo_student_t_pdf(ctx):
        print("demo_student_t_pdf")
        return

    # 5.4.32 Student t distribution, cdf and sf
    def demo_student_t_cdf(ctx):
        print("demo_student_t_cdf")
        return

    # 5.4.33 Student t distribution, qtf and isf
    def demo_student_t_qtf(ctx):
        print("demo_student_t_qtf")
        return


    # 5.4.34 Skew t distribution, pdf
    def demo_skewt_pdf(ctx):
        print("demo_skewt_pdf")
        return

    # 5.4.35 Skew t distribution, cdf and sf
    def demo_skewt_cdf(ctx):
        print("demo_skewt_cdf")
        return

    # 5.4.36 Skew t distribution, qtf and isf
    def demo_skewt_qtf(ctx):
        print("demo_skewt_qtf")
        return


    # 5.4.37 Pearson’s rho distribution (under H0): pdf
    def demo_pearson_rho_pdf(ctx):
        print("demo_pearson_rho_pdf")
        return

    # 5.4.38 Pearson’s rho distribution (under H0): cdf and sf
    def demo_pearson_rho_cdf(ctx):
        print("demo_pearson_rho_cdf")
        return

    # 5.4.39 Pearson’s rho distribution (under H0): qtf and isf
    def demo_pearson_rho_qtf(ctx):
        print("demo_pearson_rho_qtf")
        return

    demo_fisher_f_pdf(ctx)
    demo_fisher_f_cdf(ctx)
    demo_fisher_f_qtf(ctx)

    demo_fisher_z_pdf(ctx)
    demo_fisher_z_cdf(ctx)
    demo_fisher_z_sf(ctx)
    demo_fisher_z_qtf(ctx)
    demo_fisher_z_isf(ctx)
    demo_fisher_z(ctx)

    demo_student_t_pdf(ctx)
    demo_student_t_cdf(ctx)
    demo_student_t_qtf(ctx)

    demo_skewt_pdf(ctx)
    demo_skewt_cdf(ctx)
    demo_skewt_qtf(ctx)

    demo_pearson_rho_pdf(ctx)
    demo_pearson_rho_cdf(ctx)
    demo_pearson_rho_qtf(ctx)

    return






def demo_5(ctx):
    demo_5_1_part1_closed_form_elementary(ctx)
    demo_5_1_part2_closed_form_elementary(ctx)
    demo_5_1_part3_closed_form_elementary(ctx)
    demo_5_1_part4_closed_form_elementary(ctx)

    demo_5_2_part1_closed_form_error_function(ctx)
    demo_5_2_part2_closed_form_error_function(ctx)
    demo_5_2_part3_closed_form_error_function(ctx)

    demo_5_3_part1_closed_form_incomplete_gamma_function(ctx)
    demo_5_3_part2_closed_form_incomplete_gamma_function(ctx)
    demo_5_3_part3_closed_form_incomplete_gamma_function(ctx)

    demo_5_4_part1_closed_form_incomplete_beta_function(ctx)
    demo_5_4_part2_closed_form_incomplete_beta_function(ctx)
    demo_5_4_part3_closed_form_incomplete_beta_function(ctx)


    return


mpm.dps=35
dpm.dps=mpm.dps
ipm.dps=mpm.dps


print("dps: ", mpm.dps)

#ctxm = ipm
#ctxm = dpm
ctxm = mpm


demo_5(ctxm)


