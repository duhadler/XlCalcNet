

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm
import numpy as np

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_vdot_2d()
    # demo_vdot_cplx()



def demo_vdot_2d():
# Note: apm does not work in 2d real, can probably not be corrected
# However, see https://mgarod.medium.com/dynamically-add-a-method-to-a-class-in-python-c49204b85bd6

    for ctx in [qpm, fpm, mpm, ipm, dpm, gpm]: 
        print()
        print(ctx.name)

        a = npm.array([[1, 4], [5, 6]], dtype=ctx); print('a: ', a)
        b = npm.array([[4, 1], [2, 2]], dtype=ctx); print('b: ', b)
        print('npm.vdot(a, b): \n', npm.vdot(a, b)); 


def demo_vdot_cplx():
    for ctx in [fpm, mpm, ipm, dpm, gpm, apm]: 
        print()
        print(ctx.name)
        a = npm.array([1+2j,3+4j], dtype=ctx); print('a: ', a)
        b = npm.array([5+6j,7+8j], dtype=ctx); print('b: ', b)
        print('npm.vdot(a, b): \n', npm.vdot(a, b)); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




