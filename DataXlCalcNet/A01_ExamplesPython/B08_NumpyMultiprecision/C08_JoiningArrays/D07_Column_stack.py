
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_column_stack()



def demo_column_stack():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array((1, 2, 3), dtype=ctx); print('x: ', x)
        y = npm.array((4, 5, 6), dtype=ctx); print('y: ', y)
        print('column_stack(x, y): \n', npm.column_stack((x, y))); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




