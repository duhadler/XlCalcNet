
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_atleast_1d()



def demo_atleast_1d():
    print('npm.atleast_1d(ctx.t(1.0)): ')
    for ctx in ctx_all: 
        x = npm.atleast_1d(ctx.t(1.0))
        print(ctx.name + ': ', x); 

    print()
    print('npm.atleast_1d(ctx.t(1.0), [ctx.t(3), ctx.t(4)]): ')
    for ctx in ctx_all: 
        x = npm.atleast_1d(ctx.t(1.0), [ctx.t(3), ctx.t(4)])
        print(ctx.name + ': ', x); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




