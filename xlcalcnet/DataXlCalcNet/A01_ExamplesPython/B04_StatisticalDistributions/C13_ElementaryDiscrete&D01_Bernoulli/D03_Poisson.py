import time
import math
from xlcalcnet import gui; gui.adduserpath()
from A01_ExamplesPython.B18_FunctionsAndCurvesPlots.C01_Intro_Parametric2D import D02_DistPlot;
DistPlot = D02_DistPlot.DistPlot
from xlcalcnet import sreal, dreal, ereal, qreal, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

ctxlist = [sreal, dreal, ereal, qreal, oreal, mreal]


funclist = ['pmf', 'cdf', 'sf', 'hf', 'chf', 'qtf', 'isf', 'mean', 'median', \
    'mode', 'variance', 'stdev', 'skewness', 'kurtosis', 'kurtosis_excess', \
    'support_lower_endpoint', 'support_upper_endpoint', 'range_lower_endpoint', 'range_upper_endpoint']

#funclist = ['pmf']


def main_tests():
    DemoDistPoisson()
    DemoPlotDistPoisson()


def DemoDistPoisson():
    print('DemoDistPoisson: ');
    mulist = [5.1, 8.8]
    for mu in mulist:
        distlist = []
        for ctx in ctxlist:
            distlist.append(ctx.dist_poisson(mu));
        Title = 'dist=DistPoisson, mu=' + str(mu)
        xlist = [1,2,3]
        xlist = [1]
        gui.showdist_xlist(Title, xlist, distlist, funclist)
        print()
        #qlist = [0.05, 0.5, 0.95]
        qlist = [0.05]
        gui.showdist_qlist(Title, qlist, distlist, funclist)
        print()
        gui.showdist_list(Title, distlist, funclist)




def DemoPlotDistPoisson():
    Title = 'Poisson distribution'
    target = 'cdf' # pmf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
    mu = [5.1, 8.8]
    xlim = [0.0, 20.0]
    ylim = None

    dlist = []
    ltext = []
    for j in range(len(mu)):
        dlist.append(dreal.dist_poisson(mu[j]))
        ltext.append('mu=' + str(mu[j]))
    DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext, lattice=True, marker='o')



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











