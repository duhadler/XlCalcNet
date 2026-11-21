import time
import math
from xlcalcnet import gui; gui.adduserpath()
from A01_ExamplesPython.B18_FunctionsAndCurvesPlots.C01_Intro_Parametric2D import D02_DistPlot;
DistPlot = D02_DistPlot.DistPlot
from xlcalcnet import sreal, dreal, ereal, qreal

ctxlist = [sreal, dreal, ereal, qreal]


funclist = ['pdf', 'cdf', 'sf', 'hf', 'chf', 'qtf', 'isf', 'mean', 'median', \
    'mode', 'variance', 'stdev', 'skewness', 'kurtosis', 'kurtosis_excess', \
    'support_lower_endpoint', 'support_upper_endpoint', \
    'range_lower_endpoint', 'range_upper_endpoint']

#funclist = ['pdf']


def main_tests():
    DemoDistKolmogorovSmirnov()
    DemoPlotDistKolmogorovSmirnov()


def DemoDistKolmogorovSmirnov():
    print('DemoDistKolmogorovSmirnov: ');
    nlist = [5, 18]
    for n in nlist:
        distlist = []
        for ctx in ctxlist:
            distlist.append(ctx.dist_kolmogorov_smirnov(n));
        Title = 'dist=dist_kolmogorov_smirnov, n=' + str(n)
        xlist = [1,2,3]
        #xlist = [0.1]
        gui.showdist_xlist(Title, xlist, distlist, funclist)
        print()
        #qlist = [0.05, 0.5, 0.95]
        qlist = [0.05]
        gui.showdist_qlist(Title, qlist, distlist, funclist)
        print()
        gui.showdist_list(Title, distlist, funclist)


def DemoPlotDistKolmogorovSmirnov():
    Title = 'Kolmogorov-Smirnov distribution'
    target = 'pdf' # pdf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
    n = [5, 14, 25]
    xlim = [0.0, 0.8]
    ylim = None
    if target=='hf': ylim=[0, 6]

    dlist = []
    ltext = []
    for j in range(len(n)):
        dlist.append(dreal.dist_kolmogorov_smirnov(n[j]))
        ltext.append('n=' + str(n[j]))
    DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











