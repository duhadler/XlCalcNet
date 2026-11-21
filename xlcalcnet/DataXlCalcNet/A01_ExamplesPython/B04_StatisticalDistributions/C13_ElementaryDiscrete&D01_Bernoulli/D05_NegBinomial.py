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
    DemoDistNegBinomial()
    DemoPlotDistNegBinomial()


def DemoDistNegBinomial():
    print('DemoDistNegBinomial: ');
    rlist = [15, 35]
    plist = [0.1, 0.8]
    for r in rlist:
        for p in plist:
            distlist = []
            for ctx in ctxlist:
                distlist.append(ctx.dist_negbinomial(r, p));
            Title = 'dist=DistNegBinomial, r=' + str(r) + ', p=' + str(p)
            xlist = [1,2,3]
            xlist = [1]
            gui.showdist_xlist(Title, xlist, distlist, funclist)
            print()
            #qlist = [0.05, 0.5, 0.95]
            qlist = [0.05]
            gui.showdist_qlist(Title, qlist, distlist, funclist)
            print()
            gui.showdist_list(Title, distlist, funclist)


def DemoPlotDistNegBinomial():
    Title = 'NegBinomial distribution'
    target = 'pmf' # pmf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
    r = [15, 15, 15]
    p = [0.1, 0.5, 0.9]
    xlim = [0.0, 15.0]
    ylim = None

    dlist = []
    ltext = []
    for j in range(len(r)):
        dlist.append(dreal.dist_negbinomial(r[j], p[j]))
        ltext.append('r=' + str(r[j]) + ', p=' + str(p[j]))
    DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext, lattice=True, marker='o')




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











