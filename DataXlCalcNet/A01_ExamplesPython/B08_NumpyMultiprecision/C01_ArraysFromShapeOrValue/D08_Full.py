
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
ctx_fp = [fpm, mpm, ipm, dpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_full_finite()
#    demo_full_inf()
#    demo_full_nan()


def demo_full_finite():
    print()
    print('<H1 Title="full_finite">')
    for ctx in ctx_all: matB = npm.full(shape=(2,2), fill_value=ctx.t(10)); print(ctx.name + ':\n', matB)
    print('</H1>')


def demo_full_inf():
    print()
    print('<H1 Title="full_inf">')
    for ctx in ctx_fp: matB = npm.full(shape=(2,2), fill_value=ctx.inf); print(ctx.name + ':\n', matB)
    print('</H1>')



def demo_full_nan():
    print()
    print('<H1 Title="full_nan">')
    for ctx in ctx_fp: matB = npm.full(shape=(2,2), fill_value=ctx.nan); print(ctx.name + ':\n', matB)
    print('</H1>')


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




