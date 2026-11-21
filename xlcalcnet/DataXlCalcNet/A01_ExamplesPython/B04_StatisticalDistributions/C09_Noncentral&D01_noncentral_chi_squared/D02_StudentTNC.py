import time
import math
from xlcalcnet import gui; gui.adduserpath()
from A01_ExamplesPython.B18_FunctionsAndCurvesPlots.C01_Intro_Parametric2D import D02_DistPlot;
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
    DemoDistStudentTNc()
    DemoPlotDistStudentTNc()


def DemoDistStudentTNc():
    print('DemoDistStudentTNc: ');
    nlist = [2.5, 11.5]
    deltalist = [2.1, 3.8]
    for n in nlist:
        for delta in deltalist:
            distlist = []
            for ctx in ctxlist:
                distlist.append(ctx.dist_student_t_nc(n, delta));
            Title = 'dist=DistStudentTNc, n=' + str(n) + \
                    ', delta=' + str(delta)
            xlist = [1,2,3]
            xlist = [1]
            gui.showdist_xlist(Title, xlist, distlist, funclist)
            print()
            #qlist = [0.05, 0.5, 0.95]
            qlist = [0.05]
            gui.showdist_qlist(Title, qlist, distlist, funclist)
            print()
            gui.showdist_list(Title, distlist, funclist)


def DemoPlotDistStudentTNc():
    Title = 'Noncentral Student t distribution'
    target = 'pdf' # pdf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
    n = [2.5, 4.0, 11.5]
    delta = [-5.1, 0.0, 8.8]
    xlim = [-20.0, 20.0]
    ylim = None
    if target=='hf': ylim=[0, 6]

    dlist = []
    ltext = []
    for j in range(len(n)):
        dlist.append(dreal.dist_student_t_nc(n[j], delta[j]))
        ltext.append('n=' + str(n[j]) + ', delta=' + str(delta[j]))
    DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











