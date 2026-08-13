# !!! mreal does not handle double input correctly
import time
import math
from xlcalcnet import gui; gui.adduserpath()
from A01_ExamplesPython.B19_FunctionsPlots.C01_Intro import D02_DistPlot;
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
    DemoDistGeometric()
    DemoPlotDistGeometric()


def DemoDistGeometric():
    print('DemoDistGeometric: ');
    plist = [0.1, 0.8]
    for p in plist:
        distlist = []
        for ctx in ctxlist:
            distlist.append(ctx.dist_geometric(p));
        Title = 'dist=geometric, p=' + str(p)
        xlist = [0,1,2,3]
        #xlist = [1]
        gui.showdist_xlist(Title, xlist, distlist, funclist)
        print()
        #qlist = [0.05, 0.5, 0.95]
        qlist = [0.05]
        gui.showdist_qlist(Title, qlist, distlist, funclist)
        print()
        gui.showdist_list(Title, distlist, funclist)


def DemoPlotDistGeometric():
    Title = 'Geometric distribution'
    target = 'pmf' # pmf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
    p = [0.1, 0.5, 0.9]
    xlim = [0.0, 8.0]
    ylim = None

    dlist = []
    ltext = []
    for j in range(len(p)):
        dlist.append(dreal.dist_geometric(p[j]))
        ltext.append('p=' + str(p[j]))
    DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext, lattice=True, marker='o')



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











