
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_copyto1d()
    demo_copyto2d()



def demo_copyto1d():
    print()
    for ctx in ctx_all: 
        A = npm.array([4, 5, 6], dtype=ctx)
        B = npm.t(ctx, [1, 2, 3])
        np.copyto(A, B)
        print(A)



def demo_copyto2d():
    print()
    for ctx in ctx_all: 
        A = npm.array([[1, 2, 3], [4, 5, 6]], dtype=ctx)
        B = npm.t(ctx, [[4, 5, 6], [7, 8, 9]])
        np.copyto(A, B)
        print(A)


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




