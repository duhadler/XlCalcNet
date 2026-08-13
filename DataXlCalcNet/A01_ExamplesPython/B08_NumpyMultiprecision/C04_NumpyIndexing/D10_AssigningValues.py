
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_assigning_values_to_indexed_arrays()



def demo_assigning_values_to_indexed_arrays():
    print('demo_assigning_values_to_indexed_arrays:')
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(10, dtype=ctx); print('x: ', x)

        print('x[2:7] = ctx.t(1)')
        x[2:7] = ctx.t(1); print('x: ', x) 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




