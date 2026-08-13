
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
    demo_conj_cplx()
    demo_conj_cplx_ctx()
    demo_conj_cplx_re_im_ctx()
    demo_conj_cplx_mpm_ctx()



def demo_conj_cplx():
    print('<H1 Title="conj_cplx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        res = cmath53.conj(x)
        print('cmath53: conj(x=' + str(x) + '): ' + cmath53.fmt(res))
        res = scplx.conj(x)
        print('  scplx: conj(x=' + str(x) + '): ' + scplx.fmt(res))
        res = dcplx.conj(x)
        print('  dcplx: conj(x=' + str(x) + '): ' + dcplx.fmt(res))
        res = ecplx.conj(x)
        print('  ecplx: conj(x=' + str(x) + '): ' + ecplx.fmt(res))
        res = qcplx.conj(x)
        print('  qcplx: conj(x=' + str(x) + '): ' + qcplx.fmt(res))
        res = ocplx.conj(x)
        print('  ocplx: conj(x=' + str(x) + '): ' + ocplx.fmt(res))

        if use_xlcalcnet2:
            res = mcplx.conj(x)
            print('  mcplx: conj(x=' + str(x) + '): ' + mcplx.fmt(res))
            res = sflintc.conj(x)
            print('sflintc: conj(x=' + str(x) + '): ' + sflintc.fmt(res))
            res = dflintc.conj(x)
            print('dflintc: conj(x=' + str(x) + '): ' + dflintc.fmt(res))
            res = eflintc.conj(x)
            print('eflintc: conj(x=' + str(x) + '): ' + eflintc.fmt(res))
            res = qflintc.conj(x)
            print('qflintc: conj(x=' + str(x) + '): ' + qflintc.fmt(res))
            res = oflintc.conj(x)
            print('oflintc: conj(x=' + str(x) + '): ' + oflintc.fmt(res))
            res = mflintc.conj(x)
            print('mflintc: conj(x=' + str(x) + '): ' + mflintc.fmt(res))
            res = aflintc.conj(x)
            print('aflintc: conj(x=' + str(x) + '): ' + aflintc.fmt(res))
        print()
    print('</H1>')
    print()


def demo_conj_cplx_ctx():
    print('<H1 Title="conj_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.conj(x)
            print(name + ': conj(x=' + str(x) + '): ' + ctx.fmt(res))
        print()
    print('</H1>')
    print()


def demo_conj_cplx_re_im_ctx():
    print('<H1 Title="conj_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.conj(x)
            print(name + ': Re(conj(x=' + str(x) + ')): ' + \
                    ctx.realctx.fmt(ctx.real(res)))
        print()
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.conj(x)
            print(name + ': Im(conj(x=' + str(x) + ')): ' + \
                    ctx.realctx.fmt(ctx.imag(res)))
        print()
    print('</H1>')
    print()


def demo_conj_cplx_mpm_ctx():
    print('<H1 Title="conj_cplx_mpm_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctx3:
            res = ctx.conj(x)
            print(ctx.name + ': conj(x=' + str(x) + '): ' + str(res))
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











