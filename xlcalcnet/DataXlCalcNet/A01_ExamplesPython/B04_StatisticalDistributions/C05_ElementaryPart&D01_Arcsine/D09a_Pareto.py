import time
import math
from xlcalcnet import gui; gui.adduserpath()
from A01_ExamplesPython.B18_FunctionsAndCurvesPlots.C01_Intro_Parametric2D import D02_DistPlot;
DistPlot = D02_DistPlot.DistPlot
from xlcalcnet import sreal, dreal, ereal, qreal, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

ctxlist = [sreal, dreal, ereal, qreal, oreal, mreal]


funclist = ['pdf', 'cdf', 'sf', 'hf', 'chf', 'qtf', 'isf', 'mean', 'median', \
    'mode', 'variance', 'stdev', 'skewness', 'kurtosis', 'kurtosis_excess', \
    'support_lower_endpoint', 'support_upper_endpoint', \
    'range_lower_endpoint', 'range_upper_endpoint']

#funclist = ['pdf']


def main_tests():
    DemoDistPareto()
    DemoPlotDistPareto()


def DemoDistPareto():
    print('DemoDistPareto: ');
    klist = [1.5, 2.5]
    alist = [5.1, 8.8]
    for k in klist:
        for a in alist:
            distlist = []
            for ctx in ctxlist:
                distlist.append(ctx.dist_pareto(k, a));
            Title = 'dist=pareto, k=' + str(k) + ', a=' + str(a)
            xlist = [1,2,3]
            xlist = [3]
            gui.showdist_xlist(Title, xlist, distlist, funclist)
            print()
            #qlist = [0.05, 0.5, 0.95]
            qlist = [0.05]
            gui.showdist_qlist(Title, qlist, distlist, funclist)
            print()
            gui.showdist_list(Title, distlist, funclist)


def DemoPlotDistPareto():
    Title = 'Pareto distribution'
    target = 'isf' # pdf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
    k = [0.5, 1.0, 2.5]
    a = [5.1, 6.1, 8.8]
    xlim = [0.0, 4.0]
    ylim = None
    if target=='hf': ylim=[0, 6]

    dlist = []
    ltext = []
    for j in range(len(a)):
        dlist.append(dreal.dist_pareto(k[j], a[j]))
        ltext.append('k=' + str(k[j]) + ', a=' + str(a[j]))
    DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











