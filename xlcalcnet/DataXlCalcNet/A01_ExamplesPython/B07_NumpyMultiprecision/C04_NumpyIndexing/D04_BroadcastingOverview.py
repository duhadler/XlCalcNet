
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_broadcasting_overview()



def demo_broadcasting_overview():
    print('demo_broadcasting_overview:')
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.array([1.0, 2.0, 3.0], dtype=ctx); print('a: ', a)
        b = npm.array([2.0, 2.0, 2.0], dtype=ctx); print('b: ', b)
        print('a * b : ', a * b)

        b = 2; print('b: ', b)
        print('a * b : ', a * b)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




