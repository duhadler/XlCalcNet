
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
    demo_sign_cplx()
    demo_sign_cplx_ctx()
    demo_sign_cplx_re_im_ctx()
    demo_sign_cplx_mpm_ctx()



def demo_sign_cplx():
    print('<H1 Title="sign_cplx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        res = cmath53.sign(x)
        print('cmath53: sign(x=' + str(x) + '): ' + cmath53.fmt(res))
        res = scplx.sign(x)
        print('  scplx: sign(x=' + str(x) + '): ' + scplx.fmt(res))
        res = dcplx.sign(x)
        print('  dcplx: sign(x=' + str(x) + '): ' + dcplx.fmt(res))
        res = ecplx.sign(x)
        print('  ecplx: sign(x=' + str(x) + '): ' + ecplx.fmt(res))
        res = qcplx.sign(x)
        print('  qcplx: sign(x=' + str(x) + '): ' + qcplx.fmt(res))
        res = ocplx.sign(x)
        print('  ocplx: sign(x=' + str(x) + '): ' + ocplx.fmt(res))

        if use_xlcalcnet2:
            res = mcplx.sign(x)
            print('  mcplx: sign(x=' + str(x) + '): ' + mcplx.fmt(res))
            res = sflintc.sign(x)
            print('sflintc: sign(x=' + str(x) + '): ' + sflintc.fmt(res))
            res = dflintc.sign(x)
            print('dflintc: sign(x=' + str(x) + '): ' + dflintc.fmt(res))
            res = eflintc.sign(x)
            print('eflintc: sign(x=' + str(x) + '): ' + eflintc.fmt(res))
            res = qflintc.sign(x)
            print('qflintc: sign(x=' + str(x) + '): ' + qflintc.fmt(res))
            res = oflintc.sign(x)
            print('oflintc: sign(x=' + str(x) + '): ' + oflintc.fmt(res))
            res = mflintc.sign(x)
            print('mflintc: sign(x=' + str(x) + '): ' + mflintc.fmt(res))
            res = aflintc.sign(x)
            print('aflintc: sign(x=' + str(x) + '): ' + aflintc.fmt(res))
        print()
    print('</H1>')
    print()


def demo_sign_cplx_ctx():
    print('<H1 Title="sign_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.sign(x)
            print(name + ': sign(x=' + str(x) + '): ' + ctx.fmt(res))
        print()
    print('</H1>')
    print()


def demo_sign_cplx_re_im_ctx():
    print('<H1 Title="sign_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.sign(x)
            print(name + ': Re(sign(x=' + str(x) + ')): ' + \
                    ctx.realctx.fmt(ctx.real(res)))
        print()
        for ctx in ctxlist:
            name = FormatCtxNameC(ctx.name)
            res = ctx.sign(x)
            print(name + ': Im(sign(x=' + str(x) + ')): ' + \
                    ctx.realctx.fmt(ctx.imag(res)))
        print()
    print('</H1>')
    print()


def demo_sign_cplx_mpm_ctx():
    print('<H1 Title="sign_cplx_mpm_ctx">')
    xlist = [-5.1+2j, 8.8+2j]
    for x in xlist:
        for ctx in ctx3:
            res = ctx.sign(x)
            print(ctx.name + ': sign(x=' + str(x) + '): ' + str(res))
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











