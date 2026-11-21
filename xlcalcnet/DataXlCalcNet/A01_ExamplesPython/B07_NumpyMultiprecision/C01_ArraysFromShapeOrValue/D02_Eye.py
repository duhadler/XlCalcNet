
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)


def main_tests():
    demo_eye()


def demo_eye():
    print()
    print('<H1 Title="Eye">')
    for ctx in ctx_all:
        matB = npm.eye(N=3, M=4, k=1, dtype=ctx)
        print(ctx.name + ":\n", matB)
    print("</H1>")


try:
    main_tests()

except Exception:
    import traceback

    print(traceback.format_exc())
