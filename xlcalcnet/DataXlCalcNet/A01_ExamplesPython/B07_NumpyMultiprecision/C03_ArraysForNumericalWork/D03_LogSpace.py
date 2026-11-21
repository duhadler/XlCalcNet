
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_logspace()



def demo_logspace():
    print()
    print('logspace with endpoint=True:')
    for ctx in ctx_all: print(npm.logspace(start=2, stop=3, num=4, dtype=ctx))

    print()
    print('logspace with endpoint=False:')
    for ctx in ctx_all: print(npm.logspace(start=2, stop=3, num=4, dtype=ctx, endpoint=False))



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




