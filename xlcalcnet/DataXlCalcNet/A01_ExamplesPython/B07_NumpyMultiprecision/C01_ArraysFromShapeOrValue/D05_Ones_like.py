
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_ones_like()



def demo_ones_like():
    print()
    print('<H1 Title="Ones_like">')
    x = np.arange(6); x = x.reshape((2, 3))
    for ctx in ctx_all: matB = npm.ones_like(x, dtype=ctx); print(ctx.name + ':\n', matB)
    print('</H1>')


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




