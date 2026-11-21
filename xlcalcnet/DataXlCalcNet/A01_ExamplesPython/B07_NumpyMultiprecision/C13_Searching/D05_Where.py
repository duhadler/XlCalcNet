
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_where()



def demo_where():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.arange(10, dtype=ctx); print('a: ', a)
        print('npm.where(a < 5, a, 10*a): \n', npm.where(a < 5, a, 10*a)); 





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




