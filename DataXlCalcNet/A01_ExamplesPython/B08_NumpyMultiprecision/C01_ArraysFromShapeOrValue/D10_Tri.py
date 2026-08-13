
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
#    demo_tri0()
    demo_tri1()


def demo_tri0():
    print()
    print('demo_diag')
    for ctx in ctx_all: x = npm.tri(N=3, M=5, k=2, dtype=ctx); print(ctx.name + ':\n', x)


def demo_tri1():
    print()
    print('demo_diag')
    for ctx in ctx_all: x = npm.tri(N=3, M=5, k=-1, dtype=ctx); print(ctx.name + ':\n', x)


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




