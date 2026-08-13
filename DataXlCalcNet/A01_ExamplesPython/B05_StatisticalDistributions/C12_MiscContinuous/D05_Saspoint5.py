import time
import math
from xlcalcnet import gui; gui.adduserpath()
from A01_ExamplesPython.B19_FunctionsPlots.C01_Intro import D02_DistPlot;
DistPlot = D02_DistPlot.DistPlot
from xlcalcnet import sreal, dreal, ereal, qreal

ctxlist = [sreal, dreal, ereal, qreal]


funclist = ['pdf', 'cdf', 'sf', 'hf', 'chf', 'qtf', 'isf', 'mean', 'median', \
    'mode', 'variance', 'stdev', 'skewness', 'kurtosis', 'kurtosis_excess', \
    'support_lower_endpoint', 'support_upper_endpoint', \
    'range_lower_endpoint', 'range_upper_endpoint']

#funclist = ['pdf']


def main_tests():
    DemoDistSaspoint5()
    DemoPlotDistSaspoint5()


def DemoDistSaspoint5():
    print('DemoDistSaspoint5: ');
    alist = [0.5, 1.5]
    blist = [5.1, 8.8]
    for a in alist:
        for b in blist:
            distlist = []
            for ctx in ctxlist:
                distlist.append(ctx.dist_saspoint5(a, b));
            Title = 'dist=saspoint5, a=' + str(a) + ', b=' + str(b)
            xlist = [1,2,3]
            xlist = [0.1]
            gui.showdist_xlist(Title, xlist, distlist, funclist)
            print()
            #qlist = [0.05, 0.5, 0.95]
            qlist = [0.05]
            gui.showdist_qlist(Title, qlist, distlist, funclist)
            print()
            gui.showdist_list(Title, distlist, funclist)


def DemoPlotDistSaspoint5():
    Title = 'Saspoint5 distribution'
    target = 'pdf' # pdf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
    a = [-2.5, 0.0, 2.5]
    b = [1.0, 1.5, 2.0]
    xlim = [-10.0, 10.0]
    ylim = None
    if target=='hf': ylim=[0, 6]

    dlist = []
    ltext = []
    for j in range(len(a)):
        dlist.append(dreal.dist_saspoint5(a[j], b[j]))
        ltext.append('a=' + str(a[j]) + ', b=' + str(b[j]))
    DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











