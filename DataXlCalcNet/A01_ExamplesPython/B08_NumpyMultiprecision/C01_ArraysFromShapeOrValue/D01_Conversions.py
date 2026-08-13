
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
ctx_all_cplx = [fpm, mpm, ipm, dpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
#    from_integer()
#    from_float()
    from_complex()


def from_integer():
    print()
    print('<H1 Title="Conversion from integer">')
    matA = npm.array([[1,2,3], [4,5,6], [7,8,9]])
    for ctx in ctx_all: matB = npm.t(ctx, matA); print(ctx.name + ':\n', matB)
    print('</H1>')


def from_float():
    print()
    print('<H1 Title="Conversion from float">')
    matA = np.random.rand(3, 3)
    for ctx in ctx_all: matB = npm.t(ctx, matA); print(ctx.name + ':\n', matB)
    print('</H1>')


def from_complex():
    print()
    print('<H1 Title="Conversion from complex">')
    matA = np.random.rand(3, 3) + 1j * np.random.rand(3, 3)
    for ctx in ctx_all_cplx:
        ctx.dps=40; matB = npm.t(ctx, matA); print(ctx.name + ':\n', matB);
        print(ctx.name + ':\n', matB.conj())
    print('</H1>')


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




