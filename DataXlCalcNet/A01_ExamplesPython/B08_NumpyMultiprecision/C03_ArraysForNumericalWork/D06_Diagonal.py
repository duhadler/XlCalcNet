
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
#    demo_diagonal_2D()
#    demo_diagonal_3D()
    demo_antidiagonal()


def demo_diagonal_2D():
    print()
    print('demo_diagonal')
    for ctx in ctx_all: 
        x = npm.arange(4, dtype=ctx).reshape((2,2)); 
        print()
        print('x: \n', x)
        print('diagonal(x): \n', npm.diagonal(x))
        print('x.diagonal(): \n', x.diagonal())

        print('diagonal(x,1): \n', npm.diagonal(x,1))
        print('x.diagonal(1): \n', x.diagonal(1))




def demo_diagonal_3D():
    print()
    print('demo_diagonal')
    for ctx in ctx_all: 
        x = npm.arange(8, dtype=ctx).reshape((2,2,2)); 
        print()
        print(ctx.name + ', x: \n', x)
        print('diagonal(x,0,0,1): \n', npm.diagonal(x,0,0,1))
        print('x.diagonal(0,0,1): \n', x.diagonal(0,0,1))



def demo_antidiagonal():
    print()
    print('demo_antidiagonal')
    for ctx in ctx_all: 
        x = npm.arange(9, dtype=ctx).reshape((3,3)); 
        print()
        print(ctx.name + ', x: \n', x)
        print('fliplr(a).diagonal(): \n', npm.fliplr(x).diagonal())
        print('flipud(a).diagonal(): \n', npm.flipud(x).diagonal())




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




