
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
    demo_imag_cplx()
    demo_imag_cplx_ctx()
    demo_imag_cplx_re_im_ctx()
    demo_imag_cplx_mpm_ctx()



def demo_imag_cplx():
    print('<H1 Title="imag_cplx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        res = cmath53.imag(x)
        print('cmath53: imag(x=' + str(x) + '): ' + cmath53.fmt(res))
        res = scplx.imag(x)
        print('  scplx: imag(x=' + str(x) + '): ' + scplx.fmt(res))
        res = dcplx.imag(x)
        print('  dcplx: imag(x=' + str(x) + '): ' + dcplx.fmt(res))
        res = ecplx.imag(x)
        print('  ecplx: imag(x=' + str(x) + '): ' + ecplx.fmt(res))
        res = qcplx.imag(x)
        print('  qcplx: imag(x=' + str(x) + '): ' + qcplx.fmt(res))
        res = ocplx.imag(x)
        print('  ocplx: imag(x=' + str(x) + '): ' + ocplx.fmt(res))

        if use_xlcalcnet2:
            res = mcplx.imag(x)
            print('  mcplx: imag(x=' + str(x) + '): ' + mcplx.fmt(res))
            res = sflintc.imag(x)
            print('sflintc: imag(x=' + str(x) + '): ' + sflintc.fmt(res))
            res = dflintc.imag(x)
            print('dflintc: imag(x=' + str(x) + '): ' + dflintc.fmt(res))
            res = eflintc.imag(x)
            print('eflintc: imag(x=' + str(x) + '): ' + eflintc.fmt(res))
            res = qflintc.imag(x)
            print('qflintc: imag(x=' + str(x) + '): ' + qflintc.fmt(res))
            res = oflintc.imag(x)
            print('oflintc: imag(x=' + str(x) + '): ' + oflintc.fmt(res))
            res = mflintc.imag(x)
            print('mflintc: imag(x=' + str(x) + '): ' + mflintc.fmt(res))
            res = aflintc.imag(x)
            print('aflintc: imag(x=' + str(x) + '): ' + aflintc.fmt(res))
        print()
    print('</H1>')
    print()


def demo_imag_cplx_ctx():
    print('<H1 Title="imag_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.imag(x)
            print(name + ': imag(x=' + str(x) + '): ' + ctx.fmt(res))
        print()
    print('</H1>')
    print()


def demo_imag_cplx_re_im_ctx():
    print('<H1 Title="imag_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.imag(x)
            print(name + ': Re(imag(x=' + str(x) + ')): ' + \
                    ctx.realctx.fmt(ctx.real(res)))
        print()
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.imag(x)
            print(name + ': Im(imag(x=' + str(x) + ')): ' + \
                    ctx.realctx.fmt(ctx.imag(res)))
        print()
    print('</H1>')
    print()


def demo_imag_cplx_mpm_ctx():
    print('<H1 Title="imag_cplx_mpm_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctx3:
            res = ctx.imag(x)
            print(ctx.name + ': imag(x=' + str(x) + '): ' + str(res))
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











