
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_identity()



def demo_identity():
    print()
    print('<H1 Title="Identity">')
    for ctx in ctx_all: matB = npm.identity(n=3, dtype=ctx); print(ctx.name + ':\n', matB)
    print('</H1>')


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




