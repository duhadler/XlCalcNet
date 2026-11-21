
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_select()



def demo_select():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(6, dtype=ctx); print('x: ', x)

        condlist = [x<3, x>3]
        choicelist = [-x, x**2]
        print('npm.select(condlist, choicelist, 42): \n', npm.select(condlist, choicelist, 42)); 

        condlist = [x<=4, x>3]
        choicelist = [x, x**2]
        print('npm.select(condlist, choicelist, 55): \n', npm.select(condlist, choicelist, 55)); 





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




