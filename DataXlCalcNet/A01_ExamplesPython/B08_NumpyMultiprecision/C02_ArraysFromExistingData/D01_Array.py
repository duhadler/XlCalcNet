
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_from_list()
#    demo_more_than_one_dimension()
#    demo_minimum_dimensions_2()
#    demo_type_complex()



def demo_from_list():
    print()
    print('<H1 Title="From list">')
    for ctx in ctx_all: matB = npm.array([1, 2, 3], dtype=ctx); print(ctx.name + ':\n', matB)
    print('</H1>')


def demo_more_than_one_dimension():
    print()
    print('<H1 Title="demo_more_than_one_dimension">')
    for ctx in ctx_all: matB = npm.array([[1, 2], [3, 4]], dtype=ctx); print(ctx.name + ':\n', matB)
    print('</H1>')


def demo_minimum_dimensions_2():
    print()
    print('<H1 Title="demo_minimum_dimensions_2">')
    for ctx in ctx_all: matB = npm.array([1, 2, 3], dtype=ctx, ndmin=2); print(ctx.name + ':\n', matB)
    print('</H1>')


def demo_type_complex():
    print()
    print('<H1 Title="demo_type_provided">')
    matA = np.array([1, 2, 3], dtype=complex)
    for ctx in ctx_all: matB = npm.t(ctx, matA); print(ctx.name + ':\n', matB)
    print('</H1>')


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




