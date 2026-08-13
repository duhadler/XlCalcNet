
dps = 40; ctx2 = []
import time
from xlcalcnet import use_gpm, use_apm, use_xlcalcnet2

from xlcalcnet import cmath53, scplx, dcplx, ecplx, qcplx, ocplx
ctx1 = [cmath53, scplx, dcplx, ecplx, qcplx, ocplx]

from xlcalcnet import fpm, mpm, dpm, ipm
ctx3 = [fpm, mpm, dpm, ipm]
mpm.dps = dpm.dps = ipm.dps = dps

if use_gpm:
    from xlcalcnet import gpm
    gpm.dps = dps
    ctx3.append(gpm)

if use_apm:
    from xlcalcnet import apm
    apm.dps = dps
    ctx3.append(apm)

if use_xlcalcnet2:
    from xlcalcnet import ArbPrec, mcplx, sflintc, dflintc, eflintc, qflintc, \
        oflintc, mflintc, aflintc
    ctx2 = [mcplx, sflintc, dflintc, eflintc, qflintc, oflintc, mflintc, \
            aflintc]
    ArbPrec.SetDps(dps);

ctxlist = ctx1 + ctx2 + ctx3


def main_tests():
    """ A doc string """
    demo_fabs_cplx()
    demo_fabs_cplx_ctx()
    demo_fabs_cplx_re_im_ctx()
    demo_fabs_cplx_mpm_ctx()



def demo_fabs_cplx():
    print('<H1 Title="fabs_cplx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        res = cmath53.fabs(x)
        print('cmath53: fabs(x=' + str(x) + '): ' + cmath53.fmt(res))
        res = scplx.fabs(x)
        print('  scplx: fabs(x=' + str(x) + '): ' + scplx.fmt(res))
        res = dcplx.fabs(x)
        print('  dcplx: fabs(x=' + str(x) + '): ' + dcplx.fmt(res))
        res = ecplx.fabs(x)
        print('  ecplx: fabs(x=' + str(x) + '): ' + ecplx.fmt(res))
        res = qcplx.fabs(x)
        print('  qcplx: fabs(x=' + str(x) + '): ' + qcplx.fmt(res))
        res = ocplx.fabs(x)
        print('  ocplx: fabs(x=' + str(x) + '): ' + ocplx.fmt(res))

        if use_xlcalcnet2:
            res = mcplx.fabs(x)
            print('  mcplx: fabs(x=' + str(x) + '): ' + mcplx.fmt(res))
            res = sflintc.fabs(x)
            print('sflintc: fabs(x=' + str(x) + '): ' + sflintc.fmt(res))
            res = dflintc.fabs(x)
            print('dflintc: fabs(x=' + str(x) + '): ' + dflintc.fmt(res))
            res = eflintc.fabs(x)
            print('eflintc: fabs(x=' + str(x) + '): ' + eflintc.fmt(res))
            res = qflintc.fabs(x)
            print('qflintc: fabs(x=' + str(x) + '): ' + qflintc.fmt(res))
            res = oflintc.fabs(x)
            print('oflintc: fabs(x=' + str(x) + '): ' + oflintc.fmt(res))
            res = mflintc.fabs(x)
            print('mflintc: fabs(x=' + str(x) + '): ' + mflintc.fmt(res))
            res = aflintc.fabs(x)
            print('aflintc: fabs(x=' + str(x) + '): ' + aflintc.fmt(res))
        print()
    print('</H1>')
    print()


def demo_fabs_cplx_ctx():
    print('<H1 Title="fabs_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.fabs(x)
            print(name + ': fabs(x=' + str(x) + '): ' + ctx.fmt(res))
        print()
    print('</H1>')
    print()


def demo_fabs_cplx_re_im_ctx():
    print('<H1 Title="fabs_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.fabs(x)
            print(name + ': Re(fabs(x=' + str(x) + ')): ' + \
                    ctx.realctx.fmt(ctx.real(res)))
        print()
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.fabs(x)
            print(name + ': Im(fabs(x=' + str(x) + ')): ' + \
                    ctx.realctx.fmt(ctx.imag(res)))
        print()
    print('</H1>')
    print()


def demo_fabs_cplx_mpm_ctx():
    print('<H1 Title="fabs_cplx_mpm_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctx3:
            res = ctx.fabs(x)
            print(ctx.name + ': fabs(x=' + str(x) + '): ' + str(res))
        print()
    print()




def FormatCtxNameC(name):
    if (len(name)==3): name = '    ' + name
    if (len(name)==4): name = '   ' + name
    if (len(name)==5): name = '  ' + name
    return name


try:
    if __name__ == '__main__':
        start0 = time.time()
        main_tests()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )

except Exception:
    import traceback
    print(traceback.format_exc())











