
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_diag()



def demo_diag():
    print()
    print('demo_diag')
    for ctx in ctx_all: x = npm.arange(9, dtype=ctx).reshape((3,3)); print(ctx.name +', x: \n', x)

    print()
    for ctx in ctx_all: x = npm.arange(9, dtype=ctx).reshape((3,3)); print(ctx.name +', diag(x): \n', npm.diag(x))

    print()
    for ctx in ctx_all: x = npm.arange(9, dtype=ctx).reshape((3,3)); print(ctx.name +', diag(x, k=1): \n', npm.diag(x, k=1))

    print()
    for ctx in ctx_all: x = npm.arange(9, dtype=ctx).reshape((3,3)); print(ctx.name +', diag(x, k=-1): \n', npm.diag(x, k=-1))

    print()
    # only the diagonal values are set, the others are just 0.
    for ctx in ctx_all: x = npm.arange(9, dtype=ctx).reshape((3,3)); print(ctx.name +', npm.diag(npm.diag(x)): \n', npm.diag(npm.diag(x)))


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




