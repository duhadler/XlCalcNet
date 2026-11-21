
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_atleast_2d()



def demo_atleast_2d():
    print('npm.atleast_2d(ctx.t(3.0)): ')
    for ctx in ctx_all: 
        x = npm.atleast_2d(ctx.t(3.0))
        print(ctx.name + ': ', x); 

    print()
    print('npm.atleast_2d(ctx.t(1), [ctx.t(1), ctx.t(2)], [[ctx.t(1), ctx.t(2)]]): ')
    for ctx in ctx_all: 
        x = npm.atleast_2d(ctx.t(1), [ctx.t(1), ctx.t(2)], [[ctx.t(1), ctx.t(2)]])
        print(ctx.name + ': ', x); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




