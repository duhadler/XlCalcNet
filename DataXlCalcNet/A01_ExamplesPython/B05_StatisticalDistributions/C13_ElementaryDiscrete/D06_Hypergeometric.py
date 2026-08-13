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
    DemoDistHypergeometric()
    DemoPlotDistHypergeometric()


def DemoDistHypergeometric():
    print('DemoDistHypergeometric: ');
    rlist = [50]
    nlist = [30]
    NNlist = [500]
    for r in rlist:
        for n in nlist:
            for NN in NNlist:
                distlist = []
                for ctx in ctxlist:
                    distlist.append(ctx.dist_hypergeometric(r, n, NN));
                Title = 'dist=DistHypergeometric, r=' + str(r) + ', n=' \
                        + str(n) + ', NN=' + str(NN)
                xlist = [1,2,3]
                xlist = [1]
                gui.showdist_xlist(Title, xlist, distlist, funclist)
                print()
                #qlist = [0.05, 0.5, 0.95]
                qlist = [0.05]
                gui.showdist_qlist(Title, qlist, distlist, funclist)
                print()
                gui.showdist_list(Title, distlist, funclist)


def DemoPlotDistHypergeometric():
    Title = 'Hypergeometric distribution'
    target = 'pmf' # pmf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
    r = [50, 50, 50]
    n = [20, 30, 40]
    NN = [500, 500, 500]
    xlim = [0.0, 12.0]
    ylim = None

    dlist = []
    ltext = []
    for j in range(len(r)):
        dlist.append(dreal.dist_hypergeometric(r[j], n[j], NN[j]))
        ltext.append('r=' + str(r[j]) + ', n=' + str(n[j]) + ', NN=' + str(NN[j]))
    DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext, lattice=True, marker='o')




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











