
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_geomspace()



def demo_geomspace():
    print()
    print('geomspace with endpoint=True:')
    for ctx in ctx_all: print(npm.geomspace(start=1, stop=1000, num=4, dtype=ctx))

    print()
    print('geomspace with endpoint=False:')
    for ctx in ctx_all: print(npm.geomspace(start=1, stop=1000, num=4, dtype=ctx, endpoint=False))

    print()
    print('geomspace with powers of 2:')
    for ctx in ctx_all: print(npm.geomspace(start=1, stop=256, num=9, dtype=ctx))



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




