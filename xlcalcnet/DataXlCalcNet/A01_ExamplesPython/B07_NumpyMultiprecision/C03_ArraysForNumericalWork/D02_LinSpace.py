
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_linspace()



def demo_linspace():
    print()
    print('linspace with endpoint=True:')
    for ctx in ctx_all: print(npm.linspace(start=1, stop=4, num=4, dtype=ctx))

    print()
    print('linspace with endpoint=False:')
    for ctx in ctx_all: print(npm.linspace(start=1, stop=4, num=4, dtype=ctx, endpoint=False))



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




