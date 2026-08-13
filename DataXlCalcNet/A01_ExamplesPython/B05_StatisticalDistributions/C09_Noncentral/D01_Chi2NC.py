import time
import math
from xlcalcnet import gui; gui.adduserpath()
from A01_ExamplesPython.B19_FunctionsPlots.C01_Intro import D02_DistPlot;
DistPlot = D02_DistPlot.DistPlot
from xlcalcnet import sreal, dreal, ereal, qreal, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

#ctxlist = [sreal, dreal, ereal, qreal, oreal, mreal]
ctxlist = [sreal, dreal, ereal, qreal, oreal]


funclist = ['pdf', 'cdf', 'sf', 'hf', 'chf', 'qtf', 'isf', 'mean', 'median', \
    'mode', 'variance', 'stdev', 'skewness', 'kurtosis', 'kurtosis_excess', \
    'support_lower_endpoint', 'support_upper_endpoint', \
    'range_lower_endpoint', 'range_upper_endpoint']

#funclist = ['pdf']


def main_tests():
    DemoDistChi2Nc()
    DemoPlotChi2Nc()


def DemoDistChi2Nc():
    print('DemoDistChi2Nc: ');
    nlist = [0.5, 1.5]
    lambdalist = [5.1, 8.8]
    for n in nlist:
        for lambda1 in lambdalist:
            distlist = []
            for ctx in ctxlist:
                distlist.append(ctx.dist_chi2_nc(n, lambda1));
            Title = 'dist=DistChi2Nc, n=' + str(n) + \
                    ', lambda1=' + str(lambda1)
            xlist = [1,2,3]
            xlist = [1]
            gui.showdist_xlist(Title, xlist, distlist, funclist)
            print()
            #qlist = [0.05, 0.5, 0.95]
            qlist = [0.05]
            gui.showdist_qlist(Title, qlist, distlist, funclist)
            print()
            gui.showdist_list(Title, distlist, funclist)


def DemoPlotChi2Nc():
    Title = 'Noncentral chi-squared distribution'
    target = 'pdf' # pdf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
    n = [2.5, 4.0, 11.5]
    lambda1 = [5.1, 6.1, 8.8]
    xlim = [0.0, 40.0]
    ylim = None
    if target=='hf': ylim=[0, 6]

    dlist = []
    ltext = []
    for j in range(len(n)):
        dlist.append(dreal.dist_chi2_nc(n[j], lambda1[j]))
        ltext.append('n=' + str(n[j]) + ', =' + str(lambda1[j]))
    DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











