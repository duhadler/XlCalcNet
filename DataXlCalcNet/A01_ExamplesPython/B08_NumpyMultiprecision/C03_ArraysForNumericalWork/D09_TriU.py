
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_triu2D()
    #demo_triu3D()


def demo_triu2D():
    print()
    print('demo_tril2D')
    for ctx in ctx_all: 
        print()
        x = npm.triu(npm.t(ctx, [[1,2,3],[4,5,6],[7,8,9],[10,11,12]] ), k=-1); 
        print(x)


def demo_triu3D():
    print()
    print('demo_tril2D')
    for ctx in ctx_all: 
        print()
        x = npm.triu( npm.arange(3*4*5, dtype=ctx).reshape((3,4,5)) ); 
        print(x)



def demo_from_list():
    print()
    print('<H1 Title="From list">')
    for ctx in ctx_all: matB = npm.array([1, 2, 3], dtype=ctx); print(ctx.name + ':\n', matB)
    print('</H1>')

try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




