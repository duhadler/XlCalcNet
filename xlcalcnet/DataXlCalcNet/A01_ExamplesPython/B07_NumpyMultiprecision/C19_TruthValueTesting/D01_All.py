
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_all()



def demo_all():
    print('npm.all([[True,False],[True,True]]): ', npm.all([[True,False],[True,True]]))
    print('npm.all([[True,False],[True,True]], axis=0): ', npm.all([[True,False],[True,True]], axis=0))

    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([-1, 4, 5], dtype=ctx); print('x: ', x)
        print('npm.all(x): \n', npm.all(x)); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




