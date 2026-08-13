
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_shape()



def demo_shape():
    print()
    for ctx in ctx_all: 
        x = npm.eye(3, dtype=ctx); print(ctx.name + ', x: \n', x); print('shape(x):', npm.shape(x))

    print()
    for ctx in ctx_all: 
        x = [[ctx.t(1), ctx.t(3)]]; print(ctx.name + ', x: \n', x); print('shape(x):', npm.shape(x))

    print()
    for ctx in ctx_all: 
        x = [ctx.t(0)]; print(ctx.name + ', x: \n', x); print('shape(x):', npm.shape(x))

    print()
    for ctx in ctx_all: 
        x = ctx.t(0); print(ctx.name + ', x: \n', x); print('shape(x):', npm.shape(x))


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




