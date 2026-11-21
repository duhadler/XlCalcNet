
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
#    demo_array_split()
    demo_array_split2()



def demo_array_split():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(9.0, dtype=ctx); print('x: ', x)
        print('array_split(x, 3): \n', npm.array_split(x, 3)); 


def demo_array_split2():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(8.0, dtype=ctx); print('x: ', x)
        print('array_split(x, [3, 5, 6, 10]: \n', npm.array_split(x, [3, 5, 6, 10])); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




