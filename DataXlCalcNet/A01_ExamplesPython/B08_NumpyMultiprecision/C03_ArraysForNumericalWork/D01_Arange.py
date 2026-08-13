
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_arange()



def demo_arange():
    print()
    print('arange with 1 argument:')
    for ctx in ctx_all: print(npm.arange(4, dtype=ctx))

    print()
    print('arange with 2 arguments:')
    for ctx in ctx_all: print(npm.arange(0.3, 4, dtype=ctx))

    print()
    print('arange with 3 arguments, increasing:')
    for ctx in ctx_all: print(npm.arange(1, 2, 0.25, dtype=ctx))

    print()
    print('arange with 3 arguments, decreasing:')
    for ctx in ctx_all: print(npm.arange(1, -1, -0.75, dtype=ctx))



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




