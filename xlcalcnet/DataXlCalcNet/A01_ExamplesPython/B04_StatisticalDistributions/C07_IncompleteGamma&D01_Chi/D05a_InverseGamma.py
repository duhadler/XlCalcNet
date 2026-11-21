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
    DemoDistInverseGamma()
    DemoPlotDistInverseGamma()


def DemoDistInverseGamma():
    print('DemoDistInverseGamma: ');
    alist = [1.5, 2.5]
    blist = [5.1, 8.8]
    for a in alist:
        for b in blist:
            distlist = []
            for ctx in ctxlist:
                distlist.append(ctx.dist_inverse_gamma(a, b));
            Title = 'dist=inverse_gamma, a=' + str(a) + ', b=' + str(b)
            xlist = [1,2,3]
            xlist = [1]
            gui.showdist_xlist(Title, xlist, distlist, funclist)
            print()
            #qlist = [0.05, 0.5, 0.95]
            qlist = [0.05]
            gui.showdist_qlist(Title, qlist, distlist, funclist)
            print()
            gui.showdist_list(Title, distlist, funclist)


def DemoPlotDistInverseGamma():
    Title = 'Inverse Gamma distribution'
    target = 'pdf' # pdf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
    a = [1.5, 3.0, 4.5]
    b = [1.1, 0.9, 0.8]
    xlim = [0.0, 2.0]
    ylim = None
    if target=='hf': ylim=[0, 6]

    dlist = []
    ltext = []
    for j in range(len(a)):
        dlist.append(dreal.dist_inverse_gamma(a[j], b[j]))
        ltext.append('a=' + str(a[j]) + ', b=' + str(b[j]))
    DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











