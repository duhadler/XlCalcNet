
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
    demo_real_cplx()
    demo_real_cplx_ctx()
    demo_real_cplx_re_im_ctx()
    demo_real_cplx_mpm_ctx()



def demo_real_cplx():
    print('<H1 Title="real_cplx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        res = cmath53.real(x)
        print('cmath53: real(x=' + str(x) + '): ' + cmath53.fmt(res))
        res = scplx.real(x)
        print('  scplx: real(x=' + str(x) + '): ' + scplx.fmt(res))
        res = dcplx.real(x)
        print('  dcplx: real(x=' + str(x) + '): ' + dcplx.fmt(res))
        res = ecplx.real(x)
        print('  ecplx: real(x=' + str(x) + '): ' + ecplx.fmt(res))
        res = qcplx.real(x)
        print('  qcplx: real(x=' + str(x) + '): ' + qcplx.fmt(res))
        res = ocplx.real(x)
        print('  ocplx: real(x=' + str(x) + '): ' + ocplx.fmt(res))

        if use_xlcalcnet2:
            res = mcplx.real(x)
            print('  mcplx: real(x=' + str(x) + '): ' + mcplx.fmt(res))
            res = sflintc.real(x)
            print('sflintc: real(x=' + str(x) + '): ' + sflintc.fmt(res))
            res = dflintc.real(x)
            print('dflintc: real(x=' + str(x) + '): ' + dflintc.fmt(res))
            res = eflintc.real(x)
            print('eflintc: real(x=' + str(x) + '): ' + eflintc.fmt(res))
            res = qflintc.real(x)
            print('qflintc: real(x=' + str(x) + '): ' + qflintc.fmt(res))
            res = oflintc.real(x)
            print('oflintc: real(x=' + str(x) + '): ' + oflintc.fmt(res))
            res = mflintc.real(x)
            print('mflintc: real(x=' + str(x) + '): ' + mflintc.fmt(res))
            res = aflintc.real(x)
            print('aflintc: real(x=' + str(x) + '): ' + aflintc.fmt(res))
        print()
    print('</H1>')
    print()


def demo_real_cplx_ctx():
    print('<H1 Title="real_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.real(x)
            print(name + ': real(x=' + str(x) + '): ' + ctx.fmt(res))
        print()
    print('</H1>')
    print()


def demo_real_cplx_re_im_ctx():
    print('<H1 Title="real_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.real(x)
            print(name + ': Re(real(x=' + str(x) + ')): ' + \
                    ctx.realctx.fmt(ctx.real(res)))
        print()
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.real(x)
            print(name + ': Im(real(x=' + str(x) + ')): ' + \
                    ctx.realctx.fmt(ctx.imag(res)))
        print()
    print('</H1>')
    print()


def demo_real_cplx_mpm_ctx():
    print('<H1 Title="real_cplx_mpm_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctx3:
            res = ctx.real(x)
            print(ctx.name + ': real(x=' + str(x) + '): ' + str(res))
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











