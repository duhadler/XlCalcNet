
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_from_string()



def demo_from_string():
    print()
    for ctx in ctx_all:
        x = npm.fromstring('1.1, 2.1', dtype=float, sep=',')
        matB = npm.t(ctx, x)
        print(ctx.name + ':\n', matB)

    print()
    for ctx in ctx_all:
        x = npm.fromstring('1+3j, 2+4j', dtype=complex, sep=',')
        matB = npm.t(ctx, x)
        print(ctx.name + ':\n', matB)






try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




