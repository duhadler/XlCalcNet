
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
#    demo_from_list()
#    demo_more_than_one_dimension()
    demo_type_provided()



def demo_from_list():
    print()
    print('<H1 Title="From list">')
    matA = npm.asanyarray([1, 2, 3])
    for ctx in ctx_all: matB = npm.t(ctx, matA); print(ctx.name + ':\n', matB)
    print('</H1>')


def demo_more_than_one_dimension():
    print()
    print('<H1 Title="demo_more_than_one_dimension">')
    matA = npm.asanyarray([[1, 2], [3, 4]])
    for ctx in ctx_all: matB = npm.t(ctx, matA); print(ctx.name + ':\n', matB)
    print('</H1>')


def demo_type_provided():
    print()
    print('<H1 Title="demo_type_provided">')
    matA = np.asanyarray([1, 2, 3], dtype=complex)
    for ctx in ctx_all: matB = npm.t(ctx, matA); print(ctx.name + ':\n', matB)
    print('</H1>')


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




