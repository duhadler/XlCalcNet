import time
import math
from xlcalcnet import gui; gui.adduserpath()
from A01_ExamplesPython.B19_FunctionsPlots.C01_Intro import D02_DistPlot;
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
    DemoDistChi()
    DemoPlotDistChi()


def DemoDistChi():
    print('DemoDistChi: ');
    nlist = [5.1, 8.8]
    for n in nlist:
        distlist = []
        for ctx in ctxlist:
            distlist.append(ctx.dist_chi(n));
        Title = 'dist=chi, n=' + str(n)
        xlist = [1,2,3]
        xlist = [1]
        gui.showdist_xlist(Title, xlist, distlist, funclist)
        print()
        #qlist = [0.05, 0.5, 0.95]
        qlist = [0.05]
        gui.showdist_qlist(Title, qlist, distlist, funclist)
        print()
        gui.showdist_list(Title, distlist, funclist)


def DemoPlotDistChi():
    Title = 'Chi distribution'
    target = 'pdf' # pdf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
    n = [2.1, 3.1, 4.8]
    xlim = [0.0, 5.0]
    ylim = None
    if target=='hf': ylim=[0, 6]

    dlist = []
    ltext = []
    for j in range(len(n)):
        dlist.append(dreal.dist_chi(n[j]))
        ltext.append('n=' + str(n[j]))
    DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext)


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











